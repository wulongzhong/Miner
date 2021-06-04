using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInputBev : MonoBehaviour {
    private void Update() {
        if (Input.GetKey(KeyCode.A)) {
            GameClientCommand.Instance.makePlayerMove(MsgPB.PlayerMoveType.Left);
        } else if (Input.GetKey(KeyCode.D)) {
            GameClientCommand.Instance.makePlayerMove(MsgPB.PlayerMoveType.Left);
        }
    }
}
