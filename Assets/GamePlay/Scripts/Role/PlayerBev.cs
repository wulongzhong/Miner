using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBev : MonoBehaviour {
    public void initPlayer(MsgPB.GameRoomOnePlayerCache playerCache) {
        gameObject.transform.position = new Vector3(playerCache.MLastPos.MX, playerCache.MLastPos.MY, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerCache.MLastVelocity.MX, playerCache.MLastVelocity.MY);
    }


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