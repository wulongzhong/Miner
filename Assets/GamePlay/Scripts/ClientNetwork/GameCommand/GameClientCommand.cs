using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        MsgPB.GameCommand_PlayerMove cmd = new MsgPB.GameCommand_PlayerMove();
        cmd.MMoveType = moveType;
        Vector3 pos = PlayerMgr.Instance.getSelf().gameObject.transform.position;
        Vector2 velocity = PlayerMgr.Instance.getSelf().gameObject.GetComponent<Rigidbody2D>().velocity;
        cmd.MLastPos = new MsgPB.Vector2 {MX = pos.x, MY = pos.y };
        cmd.MLastVelocity = new MsgPB.Vector2 {MX = velocity.x, MY = velocity.y };
        m_waitSendCmdInfo.MPlayerMove = cmd;
    }

    public void makePlayerJump() {
        m_bHasCmd = true;
        MsgPB.GameCommand_PlayerJump cmd = new MsgPB.GameCommand_PlayerJump();
        cmd.MNone = 1;
        m_waitSendCmdInfo.MPlayerJump = cmd;
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