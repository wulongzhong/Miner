﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoomClient {
    public class GameCommandExecute : MonoBehaviour {
        public static GameCommandExecute Instance;

        private List<MsgPB.GameFrameAllCommandInfo> m_listGameCommand;
        private uint m_updateIndex;
        private int m_frameLastCount = 0;

        private void Awake() {
            Instance = this;
            Physics2D.simulationMode = SimulationMode2D.Script;
            m_listGameCommand = new List<MsgPB.GameFrameAllCommandInfo>();
        }
        private void Start() {
            ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.GameCommandS2C), onGameCommandS2C);
        }

        private void FixedUpdate() {
            updateCommand();
        }

        public void initUpdateIndex(uint index) {
            m_updateIndex = index;
        }

        private bool executeNextCommand() {
            if (m_listGameCommand.Count == 0) {
                return false;
            }
            //excute
            MsgPB.GameFrameAllCommandInfo currCommandS2C = m_listGameCommand[0];
            if(currCommandS2C.MFrameIndex > (m_updateIndex + 1)) {
                for(uint i = m_updateIndex + 1; i < currCommandS2C.MFrameIndex; ++i) {
                    MsgPB.GameCommandRetrieveC2S msg = new MsgPB.GameCommandRetrieveC2S();
                    msg.MFrameIndex = i;
                    ClientMsgReceiver.Instance.sendMsg(msg);
                }
                return false;
            }
            m_listGameCommand.RemoveAt(0);

            m_updateIndex = currCommandS2C.MFrameIndex;
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
            return true;
        }

        private void updateCommand() {
            if (m_frameLastCount > 0) {
                m_frameLastCount--;
                Physics2D.Simulate(Time.fixedDeltaTime);

                //execute end
                if(m_frameLastCount == 0) {
                    if(RoomDataCache.Instance != null) {
                        RoomDataCache.Instance.doSaveCache(m_updateIndex);
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

            chaseFrame();
        }

        private void chaseFrame() {
            while (m_listGameCommand.Count > 2) {
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

        private void addGameCommand(MsgPB.GameFrameAllCommandInfo command) {
            if(m_listGameCommand.Count == 0) {
                m_listGameCommand.Add(command);
            }
            if (command.MFrameIndex <= m_updateIndex) {
                //丢弃
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
    }
}