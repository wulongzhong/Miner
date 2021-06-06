using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBev : MonoBehaviour {

    private MsgPB.GameRoomPlayerInfo m_playInfo;
    public MsgPB.GameRoomPlayerInfo PlayInfo { get => m_playInfo; set => m_playInfo = value; }

    public void initPlayer(MsgPB.GameRoomPlayerInfo playInfo) {
        PlayInfo = playInfo;
    }

    public void initPlayer(MsgPB.GameRoomOnePlayerCache playerCache) {
        initPlayer(playerCache.MPlayerInfo);
        gameObject.transform.position = new Vector3(playerCache.MLastPos.MX, playerCache.MLastPos.MY, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerCache.MLastVelocity.MX, playerCache.MLastVelocity.MY);
    }

    public MsgPB.GameRoomOnePlayerCache getCache() {
        MsgPB.GameRoomOnePlayerCache playerCache = new MsgPB.GameRoomOnePlayerCache();
        playerCache.MPlayerInfo = m_playInfo;
        Vector2 pos = gameObject.transform.position;
        playerCache.MLastPos = new MsgPB.Vector2 { MX = pos.x, MY = pos.y };
        Vector2 velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        playerCache.MLastVelocity = new MsgPB.Vector2 { MX = velocity.x, MY = velocity.y };
        return playerCache;
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