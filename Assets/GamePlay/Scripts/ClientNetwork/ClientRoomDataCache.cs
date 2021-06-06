using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientRoomDataCache : MonoBehaviour {
    public static ClientRoomDataCache Instance;

    private string m_roomDataCacheKey;
    private string m_gameRoomName;
    private MsgPB.GameRoomCache m_gameRoomCache;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.GameRoomCache), onGameRoomCache);
    }

    public MsgPB.GameRoomCache getGameRoomCache() {
        PlayerMgr.Instance.getCache(m_gameRoomCache);
        return m_gameRoomCache;
    }

    public void saveCache() {
        getGameRoomCache();
    }

    public void setCache(MsgPB.GameRoomCache gameRoomCache) {
        m_gameRoomCache = gameRoomCache;
        PlayerMgr.Instance.setCache(m_gameRoomCache);
    }

    public void onGameRoomCache(byte[] protobytes) {
        MsgPB.GameRoomCache cache = MsgPB.GameRoomCache.Parser.ParseFrom(protobytes);
        setCache(cache);
    }

    public void initCache() {
        m_roomDataCacheKey = "roomDataCache" + m_gameRoomName;
        setCache(MsgPB.GameRoomCache.Parser.ParseFrom(Convert.FromBase64String(PlayerPrefs.GetString(m_roomDataCacheKey, ""))));
    }
}
