using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRoomCommandFactory : WF.SimpleComponent {
    public static HandlerRoomCommandFactory Instance;
    MsgPB.GameCommandInfo m_waitSendCmdInfo;
    bool m_bHasCmd = false;

    public override bool initialize() {
        base.initialize();
        Instance = this;
        m_waitSendCmdInfo = new MsgPB.GameCommandInfo();
        return true;
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
        if (m_waitSendCmdInfo.MPlayerJump == null) {
            m_waitSendCmdInfo.MPlayerJump = new MsgPB.GameCommand_PlayerJump();
        }
        m_waitSendCmdInfo.MPlayerJump.MBJump = true;
    }

    public override void update() {
        if (!m_bHasCmd) {
            return;
        }
        ClientMsgReceiver.Instance.sendMsg(m_waitSendCmdInfo);

        m_waitSendCmdInfo = new MsgPB.GameCommandInfo();
        m_bHasCmd = false;
    }
}