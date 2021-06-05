using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomCacheServer : MonoBehaviour {
    public static GameRoomCacheServer Instance;

    private Dictionary<uint, MsgPB.GameRoomPlayerCache> m_dicPlayerCache;

    private void Awake() {
        Instance = this;
        m_dicPlayerCache = new Dictionary<uint, MsgPB.GameRoomPlayerCache>();
    }

    public void updatePlayerCache(MsgPB.GameRoomPlayerCache playerCache) {
        m_dicPlayerCache[playerCache.MPlayerInfo.MPlayerId] = playerCache;
    }

    public MsgPB.GameRoomPlayerCache getPlayerCache(uint playerId) {
        if (m_dicPlayerCache.ContainsKey(playerId)) {
            return m_dicPlayerCache[playerId];
        }
        return null;
    }

    public void createNonePlayerCache(uint playerId) {
        MsgPB.GameRoomPlayerCache nonePlayerCahce = new MsgPB.GameRoomPlayerCache();
        nonePlayerCahce.MPlayerInfo = new MsgPB.GameRoomPlayerInfo();
        nonePlayerCahce.MPlayerInfo.MPlayerId = playerId;
        m_dicPlayerCache[playerId] = nonePlayerCahce;
    }
}
