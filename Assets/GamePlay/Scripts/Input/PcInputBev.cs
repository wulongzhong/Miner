using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInputBev : MonoBehaviour {
    private void Update() {
        if(PlayerMgr.Instance.getSelf() == null) {
            return;
        }
        if (Input.GetKey(KeyCode.A)) {
            HandlerRoomCommandFactory.Instance.makePlayerMove(MsgPB.PlayerMoveType.Left);
        } else if (Input.GetKey(KeyCode.D)) {
            HandlerRoomCommandFactory.Instance.makePlayerMove(MsgPB.PlayerMoveType.Right);
        }
        if (Input.GetKey(KeyCode.Space)) {
            HandlerRoomCommandFactory.Instance.makePlayerJump();
        }
    }
}