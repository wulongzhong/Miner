using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommandExecute : MonoBehaviour {
    private List<MsgPB.GameCommandS2C> m_listGameCommand;

    private int m_updateIndex;
    private int m_frameLastCount = 0;
    private void Awake() {
        Physics2D.simulationMode = SimulationMode2D.Script;
        m_listGameCommand = new List<MsgPB.GameCommandS2C>();
    }
    private void Start() {
        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.GameCommandS2C), onGameCommandS2C);
    }

    private void FixedUpdate() {
        updateCommand();
    }

    private void executeCommand(MsgPB.GameCommandS2C currCommandS2C) {
        //excute
        m_frameLastCount = GameRoomConfig.Instance.FrameScale - 1;
        foreach (MsgPB.GameCommandInfo commandInfo in currCommandS2C.MLstGameCommandInfo) {
            if (commandInfo.MCreatePlayer != null) {
                PlayerMgr.Instance.createPlayer(commandInfo.MPlayerId, commandInfo.MCreatePlayer.MPlayerInfo);
            }
            PlayerBev playerBev = PlayerMgr.Instance.getPlayerBevById(commandInfo.MPlayerId);
            if (playerBev == null) {
                Debug.LogError("playerBev == null");
                continue;
            }
            if (commandInfo.MPlayerMove != null) {
                playerBev.doMove(commandInfo.MPlayerMove);
            }
        }

        Physics2D.Simulate(Time.fixedDeltaTime);
    }

    private void updateCommand() {
        if(m_frameLastCount > 0) {
            m_frameLastCount--;
            Physics2D.Simulate(Time.fixedDeltaTime);
            return;
        }

        if(m_listGameCommand.Count == 0) {
            return;
        }

        MsgPB.GameCommandS2C currCommandS2C = m_listGameCommand[0];
        m_listGameCommand.RemoveAt(0);
        executeCommand(currCommandS2C);

        chaseFrame();
    }

    private void chaseFrame() {
        while (m_listGameCommand.Count > 2) {
            while(m_frameLastCount > 0) {
                m_frameLastCount--;
                Physics2D.Simulate(Time.fixedDeltaTime);
            }
            MsgPB.GameCommandS2C currCommandS2C = m_listGameCommand[0];
            m_listGameCommand.RemoveAt(0);
            //excute
            executeCommand(currCommandS2C);
        }
    }

    public void onGameCommandS2C(byte[] protobytes) {
        MsgPB.GameCommandS2C msg = MsgPB.GameCommandS2C.Parser.ParseFrom(protobytes);
        m_listGameCommand.Add(msg);
    }
}
