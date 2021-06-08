using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RoomClient {
    public class RoomDataCache : MonoBehaviour {
        public static RoomDataCache Instance;

        private string m_roomDataCacheKey;
        private string m_gameRoomName;
        private MsgPB.GameRoomCache m_gameRoomCache;
        private uint m_gameRoomCacheFrameIndex = 0;

        private void Awake() {
            Instance = this;
        }

        private void Start() {
            ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.GameRoomCache), onGameRoomCache);
        }

        public MsgPB.GameRoomCache getGameRoomCache() {
            return m_gameRoomCache;
        }

        public uint getGameRoomCacheFrameIndex() {
            return m_gameRoomCacheFrameIndex;
        }

        public MsgPB.GameRoomCache updateGameRoomCache() {
            PlayerMgr.Instance.getCache(m_gameRoomCache);
            return m_gameRoomCache;
        }

        public void doSaveCache(uint frameIndex) {
            updateGameRoomCache();
            m_gameRoomCacheFrameIndex = frameIndex;
        }

        public void onGameRoomCache(byte[] protobytes) {
            m_gameRoomCache = MsgPB.GameRoomCache.Parser.ParseFrom(protobytes);
            PlayerMgr.Instance.setCache(m_gameRoomCache);
            GameCommandExecute.Instance.initUpdateIndex(m_gameRoomCache.MFrameIndex);
        }

        public void initCache() {
            m_roomDataCacheKey = "roomDataCache" + m_gameRoomName;
            m_gameRoomCache = MsgPB.GameRoomCache.Parser.ParseFrom(Convert.FromBase64String(PlayerPrefs.GetString(m_roomDataCacheKey, "")));
            m_gameRoomCache.MFrameIndex = 0;
        }
    }
}