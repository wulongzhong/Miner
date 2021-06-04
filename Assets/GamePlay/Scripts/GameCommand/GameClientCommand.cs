using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClientCommand : MonoBehaviour {
    public static GameClientCommand Instance;
    private void Awake() {
        Instance = this;
        m_waitSendCmdInfo = new MsgPB.GameCommandC2S();
    }

    MsgPB.GameCommandC2S m_waitSendCmdInfo;

    public void makePlayerMove(MsgPB.PlayerMoveType moveType) {
        MsgPB.GameCommand_PlayerMove cmd = new MsgPB.GameCommand_PlayerMove();
        cmd.MMoveType = moveType;
        m_waitSendCmdInfo.MPlayerMove = cmd;
    }

    public void makePlayerJump() {
        MsgPB.GameCommand_PlayerJump cmd = new MsgPB.GameCommand_PlayerJump();
        cmd.MNone = 1;
        m_waitSendCmdInfo.MPlayerJump = cmd;
    }

    public void FixedUpdate() {
        if (!m_waitSendCmdInfo.MHasCmd) {
            return;
        }
        ClientMsgReceiver.Instance.sendMsg(m_waitSendCmdInfo);
    }
}