using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRoomPlayer : WF.SimpleComponent {
    public static HandlerRoomPlayer Instance;

    private uint m_selfPlayerId = 1;
    private long m_key;
    private Dictionary<uint, PlayerBev> m_dicId2PlayerBec;

    public uint SelfPlayerId { get => m_selfPlayerId; set => m_selfPlayerId = value; }
    public long Key { get => m_key; set => m_key = value; }

    public override bool initialize() {
        base.initialize();
        Instance = this;
        m_dicId2PlayerBec = new Dictionary<uint, PlayerBev>();
        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.GameRoomPlayerLoginS2C), onGameRoomPlayerLoginS2C);
        return true;
    }

    public PlayerBev getPlayerBevById(uint playerId) {
        if (m_dicId2PlayerBec.ContainsKey(playerId)) {
            return m_dicId2PlayerBec[playerId];
        }
        return null;
    }

    public PlayerBev getSelf() {
        if (m_dicId2PlayerBec.ContainsKey(SelfPlayerId)) {
            return m_dicId2PlayerBec[SelfPlayerId];
        }
        return null;
    }

    public PlayerBev createPlayer(uint playerId, MsgPB.GameRoomPlayerInfo playerInfo) {
        PlayerBev playerBev = GameObjFactory.Instance.createPlayer();
        playerBev.initPlayer(playerInfo);
        m_dicId2PlayerBec[playerId] = playerBev;
        return m_dicId2PlayerBec[playerId];
    }

    public void joinGameRoom() {
        MsgPB.GameRoomPlayerLoginC2S msg = new MsgPB.GameRoomPlayerLoginC2S();
        msg.MPlayerId = SelfPlayerId;
        ClientMsgReceiver.Instance.sendMsg(msg);
    }

    public void getCache(MsgPB.GameRoomCache roomCache) {
        roomCache.MLstCachePlayer.Clear();
        foreach(var keyValue in m_dicId2PlayerBec) {
            roomCache.MLstCachePlayer.Add(keyValue.Value.getCache());
        }
    }

    public void setCache(MsgPB.GameRoomCache roomCache) {
        foreach(var playerCache in roomCache.MLstCachePlayer) {
            PlayerBev playerBev = GameObjFactory.Instance.createPlayer();
            playerBev.initPlayer(playerCache);
            m_dicId2PlayerBec[playerCache.MPlayerInfo.MPlayerId] = playerBev;
        }
    }

    public void onGameRoomPlayerLoginS2C(byte[] protobytes) {
        MsgPB.GameRoomPlayerLoginS2C msg = MsgPB.GameRoomPlayerLoginS2C.Parser.ParseFrom(protobytes);
        if (msg.MLoginSuccess) {
            m_selfPlayerId = msg.MPlayerId;
            m_key = msg.MKey;
        } else {
            //登录失败
        }
    }
}