using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameUserServer {
    using System.Collections;
    using System.Collections.Generic;
    using System.Net;

    public class PlayerServer : WF.SimpleComponent {
        private class PlayerLoginInfo {
            public uint m_playerId;
            public string m_userName;
            public string m_password;
            public string m_cacheLoginID;
        }

        private class PlayerNetInfo {
            public uint m_playerID;
            public IPEndPoint m_clientIPEndPoint;
            public IPEndPoint m_roomIPEndPoint;
            public long m_key;
            public long m_lastHeartBeatTime;
        }

        public static PlayerServer Instance;

        private Dictionary<uint, PlayerNetInfo> m_dicPlayerInfo;
        private Dictionary<IPEndPoint, PlayerNetInfo> m_dicClientIPEndPoint2PlayerInfo;
        private Dictionary<IPEndPoint, PlayerNetInfo> m_dicRoomIPEndPoint2PlayerInfo;

        private System.Random m_random;
        private uint testPlayerId = 0;

        public override bool initialize() {
            base.initialize();
            Instance = this;

            m_random = new System.Random((int)ServerMgr.Instance.NowTime);
            m_dicPlayerInfo = new Dictionary<uint, PlayerNetInfo>();
            m_dicClientIPEndPoint2PlayerInfo = new Dictionary<IPEndPoint, PlayerNetInfo>();
            m_dicRoomIPEndPoint2PlayerInfo = new Dictionary<IPEndPoint, PlayerNetInfo>();

            ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerPlayerLoginC2S), onUserServerPlayerLoginC2S);
            ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerHeartBeatC2S), onUserServerHeartBeatC2S);

            return true;
        }


        public List<uint> getAllPlayerId() {
            List<uint> m_playerIds = new List<uint>();
            foreach (var playerInfo in m_dicClientIPEndPoint2PlayerInfo.Values) {
                m_playerIds.Add(playerInfo.m_playerID);
            }
            return m_playerIds;
        }

        public void onUserServerPlayerLoginC2S(byte[] protobytes, IPEndPoint iPEndPoint) {
            MsgPB.UserServerPlayerLoginC2S msg = MsgPB.UserServerPlayerLoginC2S.Parser.ParseFrom(protobytes);

            PlayerLoginInfo playerLoginInfo = new PlayerLoginInfo();
            playerLoginInfo.m_playerId = ++testPlayerId;

            if (!m_dicPlayerInfo.ContainsKey(playerLoginInfo.m_playerId)) {
                m_dicPlayerInfo.Add(playerLoginInfo.m_playerId, new PlayerNetInfo());
            }

            PlayerNetInfo playerNetInfo = m_dicPlayerInfo[playerLoginInfo.m_playerId];
            playerNetInfo.m_playerID = playerLoginInfo.m_playerId;
            playerNetInfo.m_key = m_random.Next(int.MinValue, int.MaxValue);
            playerNetInfo.m_lastHeartBeatTime = ServerMgr.Instance.NowTime;
            playerNetInfo.m_clientIPEndPoint = iPEndPoint;

            m_dicClientIPEndPoint2PlayerInfo[playerNetInfo.m_clientIPEndPoint] = playerNetInfo;

            //告知登录成功
            MsgPB.UserServerPlayerLoginS2C loginMsg = new MsgPB.UserServerPlayerLoginS2C();
            loginMsg.MLoginSuccess = true;
            loginMsg.MPlayerId = playerNetInfo.m_playerID;
            loginMsg.MKey = playerNetInfo.m_key;
            ServerMsgReceiver.Instance.sendMsgToPlayer(playerNetInfo.m_playerID, loginMsg);
        }

        public void onUserServerHeartBeatC2S(byte[] protobytes, IPEndPoint iPEndPoint) {
            MsgPB.UserServerHeartBeatC2S msg = MsgPB.UserServerHeartBeatC2S.Parser.ParseFrom(protobytes);
            if (m_dicPlayerInfo.ContainsKey(msg.MPlayerId)) {
                PlayerNetInfo playerNetInfo = m_dicPlayerInfo[msg.MPlayerId];
                if (playerNetInfo.m_clientIPEndPoint == null) {
                    return;
                }
                if (msg.MKey == playerNetInfo.m_key) {
                    playerNetInfo.m_lastHeartBeatTime = ServerMgr.Instance.NowTime;
                    if (!playerNetInfo.m_clientIPEndPoint.Equals(iPEndPoint)) {
                        m_dicClientIPEndPoint2PlayerInfo.Remove(playerNetInfo.m_clientIPEndPoint);

                        playerNetInfo.m_clientIPEndPoint = iPEndPoint;
                        m_dicClientIPEndPoint2PlayerInfo[playerNetInfo.m_clientIPEndPoint] = playerNetInfo;
                    }
                }
            } else {
                ServerLog.log("m_dicPlayerId2Key.ContainsKey(msg.MPlayerId) = false");
            }
        }

        public IPEndPoint getIpEndPointByPlayerId(uint playerId) {
            if (m_dicPlayerInfo.ContainsKey(playerId)) {
                return m_dicPlayerInfo[playerId].m_clientIPEndPoint;
            }
            return null;
        }

        public uint getPlayerIdByIPEndPoint(IPEndPoint ipEndPoint) {
            if (m_dicClientIPEndPoint2PlayerInfo.ContainsKey(ipEndPoint)) {
                return m_dicClientIPEndPoint2PlayerInfo[ipEndPoint].m_playerID;
            }
            return 0;
        }

        public bool checkPlayerKey(uint playerId, long key) {
            if (m_dicPlayerInfo.ContainsKey(playerId)) {
                if(m_dicPlayerInfo[playerId].m_key == key) {
                    return true;
                }
            }
            return false;
        }

        long m_lastHeartBeatTime;
        public override void update() {
            foreach (var keyValue in m_dicPlayerInfo) {
                if(keyValue.Value.m_clientIPEndPoint == null) {
                    continue;
                }
                if ((ServerMgr.Instance.NowTime - keyValue.Value.m_lastHeartBeatTime) > GameConfig.Instance.HeartBeatWaitTime) {
                    m_dicClientIPEndPoint2PlayerInfo.Remove(keyValue.Value.m_clientIPEndPoint);
                    keyValue.Value.m_clientIPEndPoint = null;
                }
            }

            if ((ServerMgr.Instance.NowTime - m_lastHeartBeatTime) > GameConfig.Instance.HeartBeatIntervalTime) {
                m_lastHeartBeatTime = ServerMgr.Instance.NowTime;
                MsgPB.UserServerHeartBeatS2C msg = new MsgPB.UserServerHeartBeatS2C();
                ServerMsgReceiver.Instance.sendMsgToPlayer(getAllPlayerId(), msg);
            }
        }
    }
}
