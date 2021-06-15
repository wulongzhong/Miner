﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameUserServer {
    public class PlayerServer : WF.SimpleComponent {

        private class PlayerLoginInfo {
            uint m_playerId;
            string m_userName;
            string m_password;
            string m_cacheLoginID;
        }

        public static PlayerServer Instance;

        List<uint> m_listPlayerIds;
        private Dictionary<uint, IPEndPoint> m_dicPlayerId2IPEndPoint;
        private Dictionary<IPEndPoint, uint> m_dicIPEndPoint2PlayerId;
        private Dictionary<uint, long> m_dicPlayerId2Key;
        private Dictionary<uint, long> m_dicPlayerId2HeartBeat;
        private System.Random m_random;

        public override bool initialize() {
            base.initialize();
            Instance = this;

            m_random = new System.Random((int)ServerMgr.Instance.NowTime);

            m_listPlayerIds = new List<uint>();

            m_dicPlayerId2IPEndPoint = new Dictionary<uint, IPEndPoint>();
            m_dicIPEndPoint2PlayerId = new Dictionary<IPEndPoint, uint>();
            m_dicPlayerId2Key = new Dictionary<uint, long>();
            m_dicPlayerId2HeartBeat = new Dictionary<uint, long>();

            ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerPlayerLoginC2S), onUserServerPlayerLoginC2S);
            ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerHeartBeatC2S), onUserServerHeartBeatC2S);

            return true;
        }


        public List<uint> getAllPlayerId() {
            return new List<uint>(m_listPlayerIds);
        }

        public void onUserServerPlayerLoginC2S(byte[] protobytes, IPEndPoint iPEndPoint) {
            MsgPB.UserServerPlayerLoginC2S msg = MsgPB.UserServerPlayerLoginC2S.Parser.ParseFrom(protobytes);
            addIpEndPoint(msg.MPlayerId, iPEndPoint);

            if (!(m_listPlayerIds.Contains(msg.MPlayerId))) {
                m_listPlayerIds.Add(msg.MPlayerId);
            }
            m_dicPlayerId2Key[msg.MPlayerId] = m_random.Next(int.MinValue, int.MaxValue);
            m_dicPlayerId2HeartBeat[msg.MPlayerId] = ServerMgr.Instance.NowTime;

            //告知登录成功
            MsgPB.UserServerPlayerLoginS2C loginMsg = new MsgPB.UserServerPlayerLoginS2C();
            loginMsg.MLoginSuccess = true;
            loginMsg.MPlayerId = msg.MPlayerId;
            loginMsg.MKey = m_dicPlayerId2Key[msg.MPlayerId];
            ServerMsgReceiver.Instance.sendMsg(msg.MPlayerId, loginMsg);
        }

        public void onUserServerHeartBeatC2S(byte[] protobytes, IPEndPoint iPEndPoint) {
            MsgPB.UserServerHeartBeatC2S msg = MsgPB.UserServerHeartBeatC2S.Parser.ParseFrom(protobytes);
            if (m_dicPlayerId2Key.ContainsKey(msg.MPlayerId)) {
                if (msg.MKey == m_dicPlayerId2Key[msg.MPlayerId]) {
                    m_dicPlayerId2HeartBeat[msg.MPlayerId] = ServerMgr.Instance.NowTime;

                    if (m_dicPlayerId2IPEndPoint[msg.MPlayerId] != iPEndPoint) {
                        m_dicIPEndPoint2PlayerId.Remove(m_dicPlayerId2IPEndPoint[msg.MPlayerId]);
                        m_dicIPEndPoint2PlayerId[iPEndPoint] = msg.MPlayerId;
                        m_dicPlayerId2IPEndPoint[msg.MPlayerId] = iPEndPoint;
                    }
                }
            } else {
                ServerLog.log("m_dicPlayerId2Key.ContainsKey(msg.MPlayerId) = false");
            }
        }

        private void addIpEndPoint(uint playerId, IPEndPoint ipEndPoint) {
            m_dicPlayerId2IPEndPoint[playerId] = ipEndPoint;
            m_dicIPEndPoint2PlayerId[ipEndPoint] = playerId;
        }

        public IPEndPoint getIpEndPointByPlayerId(uint playerId) {
            if (m_dicPlayerId2IPEndPoint.ContainsKey(playerId)) {
                return m_dicPlayerId2IPEndPoint[playerId];
            }
            return null;
        }

        public uint getPlayerIdByIPEndPoint(IPEndPoint ipEndPoint) {
            if (m_dicIPEndPoint2PlayerId.ContainsKey(ipEndPoint)) {
                return m_dicIPEndPoint2PlayerId[ipEndPoint];
            }
            return 0;
        }

        long m_lastHeartBeatTime;
        public override void update() {
            List<uint> lstOfflinePlayerId = new List<uint>();
            foreach (var keyValue in m_dicPlayerId2HeartBeat) {
                if ((ServerMgr.Instance.NowTime - keyValue.Value) > 10000) {
                    lstOfflinePlayerId.Add(keyValue.Key);
                }
            }

            foreach (var offlinePlayerId in lstOfflinePlayerId) {
                m_dicPlayerId2HeartBeat.Remove(offlinePlayerId);
                m_dicIPEndPoint2PlayerId.Remove(m_dicPlayerId2IPEndPoint[offlinePlayerId]);
                m_dicPlayerId2IPEndPoint.Remove(offlinePlayerId);
            }

            if ((ServerMgr.Instance.NowTime - m_lastHeartBeatTime) > 2000) {
                m_lastHeartBeatTime = ServerMgr.Instance.NowTime;
                MsgPB.UserServerHeartBeatS2C msg = new MsgPB.UserServerHeartBeatS2C();
                ServerMsgReceiver.Instance.sendMsg(getAllPlayerId(), msg);
            }
        }
    }
}
