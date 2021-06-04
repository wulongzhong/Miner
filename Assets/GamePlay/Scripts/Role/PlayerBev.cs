using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBev : MonoBehaviour {
    public void doMove(MsgPB.GameCommand_PlayerMove cmd) {
        switch (cmd.MMoveType) {
            case MsgPB.PlayerMoveType.Stop:
                //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                break;
            case MsgPB.PlayerMoveType.Left:
                gameObject.GetComponent<Rigidbody2D>().MovePosition((Vector2)(gameObject.transform.position) + Vector2.left * Time.fixedDeltaTime);
                break;
            case MsgPB.PlayerMoveType.Right:
                gameObject.GetComponent<Rigidbody2D>().MovePosition((Vector2)(gameObject.transform.position) + Vector2.right * Time.fixedDeltaTime);
                break;
        }
    }
}