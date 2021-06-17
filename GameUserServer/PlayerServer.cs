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
            public IPEndPoint m_ipEndPoint;
            public long m_key;
            public long m_lastHeartBeatTime;
        }

        public static PlayerServer Instance;

        private Dictionary<uint, PlayerNetInfo> m_dicPlayerInfo;
        private Dictionary<IPEndPoint, PlayerNetInfo> m_dicIPEndPoint2PlayerInfo;

        private System.Random m_random;
        private uint testPlayerId = 0;

        public override bool initialize() {
            base.initialize();
            Instance = this;

            m_random = new System.Random((int)ServerMgr.Instance.NowTime);
            m_dicPlayerInfo = new Dictionary<uint, PlayerNetInfo>();
            m_dicIPEndPoint2PlayerInfo = new Dictionary<IPEndPoint, PlayerNetInfo>();

            ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerPlayerLoginC2S), onUserServerPlayerLoginC2S);
            ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerHeartBeatC2S), onUserServerHeartBeatC2S);

            return true;
        }


        public List<uint> getAllPlayerId() {
            List<uint> m_playerIds = new List<uint>();
            foreach (var playerInfo in m_dicIPEndPoint2PlayerInfo.Values) {
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
            playerNetInfo.m_ipEndPoint = iPEndPoint;

            m_dicIPEndPoint2PlayerInfo[playerNetInfo.m_ipEndPoint] = playerNetInfo;

            //告知登录成功
            MsgPB.UserServerPlayerLoginS2C loginMsg = new MsgPB.UserServerPlayerLoginS2C();
            loginMsg.MLoginSuccess = true;
            loginMsg.MPlayerId = playerNetInfo.m_playerID;
            loginMsg.MKey = playerNetInfo.m_key;
            ServerMsgReceiver.Instance.sendMsg(playerNetInfo.m_playerID, loginMsg);
        }

        public void onUserServerHeartBeatC2S(byte[] protobytes, IPEndPoint iPEndPoint) {
            MsgPB.UserServerHeartBeatC2S msg = MsgPB.UserServerHeartBeatC2S.Parser.ParseFrom(protobytes);
            if (m_dicPlayerInfo.ContainsKey(msg.MPlayerId)) {
                PlayerNetInfo playerNetInfo = m_dicPlayerInfo[msg.MPlayerId];
                if (msg.MKey == playerNetInfo.m_key) {
                    playerNetInfo.m_lastHeartBeatTime = ServerMgr.Instance.NowTime;

                    if (playerNetInfo.m_ipEndPoint != iPEndPoint) {
                        m_dicIPEndPoint2PlayerInfo.Remove(playerNetInfo.m_ipEndPoint);

                        playerNetInfo.m_ipEndPoint = iPEndPoint;
                        m_dicIPEndPoint2PlayerInfo[playerNetInfo.m_ipEndPoint] = playerNetInfo;
                    }
                }
            } else {
                ServerLog.log("m_dicPlayerId2Key.ContainsKey(msg.MPlayerId) = false");
            }
        }

        public IPEndPoint getIpEndPointByPlayerId(uint playerId) {
            if (m_dicPlayerInfo.ContainsKey(playerId)) {
                return m_dicPlayerInfo[playerId].m_ipEndPoint;
            }
            return null;
        }

        public uint getPlayerIdByIPEndPoint(IPEndPoint ipEndPoint) {
            if (m_dicIPEndPoint2PlayerInfo.ContainsKey(ipEndPoint)) {
                return m_dicIPEndPoint2PlayerInfo[ipEndPoint].m_playerID;
            }
            return 0;
        }

        long m_lastHeartBeatTime;
        public override void update() {
            foreach (var keyValue in m_dicPlayerInfo) {
                if ((ServerMgr.Instance.NowTime - keyValue.Value.m_lastHeartBeatTime) > GameConfig.Instance.HeartBeatWaitTime) {
                    m_dicIPEndPoint2PlayerInfo.Remove(keyValue.Value.m_ipEndPoint);
                    keyValue.Value.m_ipEndPoint = null;
                }
            }

            if ((ServerMgr.Instance.NowTime - m_lastHeartBeatTime) > GameConfig.Instance.HeartBeatIntervalTime) {
                m_lastHeartBeatTime = ServerMgr.Instance.NowTime;
                MsgPB.UserServerHeartBeatS2C msg = new MsgPB.UserServerHeartBeatS2C();
                ServerMsgReceiver.Instance.sendMsg(getAllPlayerId(), msg);
            }
        }
    }
}
