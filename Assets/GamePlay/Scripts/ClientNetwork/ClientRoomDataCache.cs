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
    }

    public MsgPB.GameRoomCache getGameRoomCache() {
        return m_gameRoomCache;
    }

    public void saveCache() {
        PlayerMgr.Instance.getCache(m_gameRoomCache);
    }

    public void setCache(MsgPB.GameRoomCache gameRoomCache) {
        m_gameRoomCache = gameRoomCache;

    }

    public void initCache() {
        m_roomDataCacheKey = "roomDataCache" + m_gameRoomName;
        setCache(MsgPB.GameRoomCache.Parser.ParseFrom(Convert.FromBase64String(PlayerPrefs.GetString(m_roomDataCacheKey, ""))));
    }
}
