using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandlerRoomCommandExecute : WF.SimpleComponent {
    public static HandlerRoomCommandExecute Instance;

    private List<MsgPB.GameFrameAllCommandInfo> m_listGameCommand;
    private uint m_updateIndex;
    private int m_frameLastCount = 0;
    bool m_bCanRetrieving = true;

    public override bool initialize() {
        base.initialize();
        Instance = this;
        Physics2D.autoSyncTransforms = false;
        Physics2D.simulationMode = SimulationMode2D.Script;
        m_listGameCommand = new List<MsgPB.GameFrameAllCommandInfo>();

        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.GameCommandS2C), onGameCommandS2C);
        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.GameFrameAllCommandInfo), onGameFrameAllCommandInfo);

        return true;
    }

    public override void update () {
        updateCommand();
    }

    public void initUpdateIndex(uint index) {
        m_updateIndex = index;
        Debug.LogFormat("initUpdateIndex : {0}", index);
    }

    private void updateCommand() {
        if (m_frameLastCount > 0) {
            m_frameLastCount--;
            Physics2D.Simulate(Time.fixedDeltaTime);

            //execute end
            if(m_frameLastCount == 0) {
                if(HandlerRoomDataCache.Instance != null) {
                    HandlerRoomDataCache.Instance.doSaveCache(m_updateIndex);
                }
            }
            return;
        }

        if (m_listGameCommand.Count == 0) {
            return;
        }

        if (!executeNextCommand()) {
            return;
        }
        Debug.LogFormat("m_listGameCommand.Count : {0}", m_listGameCommand.Count);
        chaseFrame();
    }

    private void chaseFrame() {
        while (m_listGameCommand.Count > GameConfig.Instance.ChaseFrameCount) {
            while (m_frameLastCount > 0) {
                m_frameLastCount--;
                Physics2D.Simulate(Time.fixedDeltaTime);
            }
            //excute
            if (!executeNextCommand()) {
                return;
            }
        }
    }

    public void onGameCommandS2C(byte[] protobytes) {
        MsgPB.GameCommandS2C msg = MsgPB.GameCommandS2C.Parser.ParseFrom(protobytes);
        foreach(var command in msg.MLstFrameAllCommandInfo) {
            addGameCommand(command);
        }
    }

    public void onGameFrameAllCommandInfo(byte[] protobytes) {
        MsgPB.GameFrameAllCommandInfo msg = MsgPB.GameFrameAllCommandInfo.Parser.ParseFrom(protobytes);
        addGameCommand(msg);
    }

    private void addGameCommand(MsgPB.GameFrameAllCommandInfo command) {
        if(m_listGameCommand.Count == 0) {
            m_listGameCommand.Add(command);
        }
        if (command.MFrameIndex <= m_updateIndex) {
            //丢弃
            return;
        }

        if(command.MFrameIndex < m_listGameCommand[0].MFrameIndex) {
            m_listGameCommand.Insert(0, command);
            return;
        }

        if (command.MFrameIndex > m_listGameCommand[m_listGameCommand.Count - 1].MFrameIndex) {
            m_listGameCommand.Add(command);
            return;
        }
        for(int i = 0; i < (m_listGameCommand.Count - 1); ++i) {
            if(command.MFrameIndex <= m_listGameCommand[i].MFrameIndex) {
                continue;
            }
            if(command.MFrameIndex >= m_listGameCommand[i + 1].MFrameIndex) {
                return;
            }
            m_listGameCommand.Insert(i + 1, command);
            return;
        }
    }


    private bool executeNextCommand() {
        if (m_listGameCommand.Count == 0) {
            return false;
        }
        //excute
        MsgPB.GameFrameAllCommandInfo currCommandS2C = m_listGameCommand[0];
        if (currCommandS2C.MFrameIndex > (m_updateIndex + 1)) {
            if (m_bCanRetrieving) {
                m_bCanRetrieving = false;
                MsgPB.GameCommandRetrieveC2S msg = new MsgPB.GameCommandRetrieveC2S();
                for (uint i = m_updateIndex + 1; i < currCommandS2C.MFrameIndex; ++i) {
                    msg.MFrameIndex.Add(i);
                }
                ClientMsgReceiver.Instance.sendMsg2RoomServer(msg);
            }
            return false;
        }

        m_bCanRetrieving = true;
        m_listGameCommand.RemoveAt(0);

        m_updateIndex = currCommandS2C.MFrameIndex;
        m_frameLastCount = GameConfig.Instance.FrameScale - 1;
        foreach (MsgPB.GameCommandInfo commandInfo in currCommandS2C.MLstGameCommandInfo) {
            if (commandInfo.MCreatePlayer != null) {
                Debug.LogFormat("executeNextCommand add player id:{0}", commandInfo.MPlayerId);
                HandlerRoomPlayer.Instance.createPlayer(commandInfo.MPlayerId, commandInfo.MCreatePlayer.MPlayerInfo);
            }
            PlayerBev playerBev = HandlerRoomPlayer.Instance.getPlayerBevById(commandInfo.MPlayerId);
            if (playerBev == null) {
                Debug.LogError("playerBev == null");
                continue;
            }
            if (commandInfo.MPlayerMove != null) {
                playerBev.doMove(commandInfo.MPlayerMove);
            }
            if(commandInfo.MPlayerJump != null) {
                playerBev.doJump(commandInfo.MPlayerJump);
            }
        }

        Physics2D.Simulate(Time.fixedDeltaTime);
        return true;
    }

}