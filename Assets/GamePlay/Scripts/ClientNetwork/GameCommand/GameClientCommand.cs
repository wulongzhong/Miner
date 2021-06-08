using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RoomClient {
    public class GameClientCommand : MonoBehaviour {
        public static GameClientCommand Instance;
        MsgPB.GameCommandInfo m_waitSendCmdInfo;
        bool m_bHasCmd = false;
        private void Awake() {
            Instance = this;
            m_waitSendCmdInfo = new MsgPB.GameCommandInfo();
        }


        public void makePlayerMove(MsgPB.PlayerMoveType moveType) {
            m_bHasCmd = true;
            if (m_waitSendCmdInfo.MPlayerMove == null) {
                m_waitSendCmdInfo.MPlayerMove = new MsgPB.GameCommand_PlayerMove();
            }
            m_waitSendCmdInfo.MPlayerMove.MMoveType = moveType;
        }

        public void makePlayerJump() {
            m_bHasCmd = true;
            if (m_waitSendCmdInfo.MPlayerMove == null) {
                m_waitSendCmdInfo.MPlayerMove = new MsgPB.GameCommand_PlayerMove();
            }
            m_waitSendCmdInfo.MPlayerMove.MBJump = true;
        }

        public void FixedUpdate() {
            if (!m_bHasCmd) {
                return;
            }
            ClientMsgReceiver.Instance.sendMsg(m_waitSendCmdInfo);

            m_waitSendCmdInfo = new MsgPB.GameCommandInfo();
            m_bHasCmd = false;
        }
    }
}