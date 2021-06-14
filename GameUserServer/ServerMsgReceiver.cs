﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace GameUserServer {
    class ServerMsgReceiver {
        public delegate void OnIpRev(byte[] protobytes, IPEndPoint iPEndPoint);
        public delegate void OnUserRev(byte[] protobytes, uint roleId);

        private const int m_listenPort = 19981;
        private UdpClient m_listener;
        private Thread m_udpListenThread;
        private bool m_serverIsRuning;

        public static ServerMsgReceiver Instance;

        private Dictionary<ushort, OnIpRev> m_onIpRevDic;
        private Dictionary<ushort, OnUserRev> m_onUserRevDic;

        public static Mutex mutex = new Mutex();
        class WaitHandler {
            public byte[] m_bytes;
            public IPEndPoint m_groupEP;
        }
        private List<WaitHandler> m_waitHandleSyncList;
        private List<WaitHandler> m_waitHandleMasterList;

        private void Awake() {
            Instance = this;
            m_onIpRevDic = new Dictionary<ushort, OnIpRev>();
            m_onUserRevDic = new Dictionary<ushort, OnUserRev>();
            m_waitHandleSyncList = new List<WaitHandler>();
            m_waitHandleMasterList = new List<WaitHandler>();
            startUdpListen();
        }
        public void startUdpListen() {
            m_listener = new UdpClient(m_listenPort);
            m_udpListenThread = new Thread(UdpListenUpdate);
            m_udpListenThread.Start();
        }

        public void UdpListenUpdate() {
            m_serverIsRuning = true;

            while (m_serverIsRuning) {
                IPEndPoint groupEP;
                groupEP = new IPEndPoint(IPAddress.Any, m_listenPort);
                try {
                    byte[] bytes = m_listener.Receive(ref groupEP);
                    mutex.WaitOne();
                    m_waitHandleSyncList.Add(new WaitHandler() { m_bytes = bytes, m_groupEP = groupEP });
                    mutex.ReleaseMutex();
                } catch (SocketException e) {
                    ServerLog.log(e.Message);
                }
            }
        }

        //对单个玩家发送消息
        public void sendMsg<T>(uint userId, T msg) {
            IPEndPoint pGroupEp = UserServer.Instance.getIpEndPointByUserId(userId);
            if (pGroupEp == null) {
                return;
            }
            IMessage data = (IMessage)(object)msg;
            byte[] msgIdByte = BitConverter.GetBytes(MsgType.getTypeId(msg.GetType()));
            byte[] msgByte = data.ToByteArray();
            byte[] sendByte = new byte[msgByte.Length + 2];
            msgIdByte.CopyTo(sendByte, 0);
            msgByte.CopyTo(sendByte, 2);
            sendMsg2Client(pGroupEp, sendByte);
        }
        //对多个玩家发送消息
        public void sendMsg<T>(List<uint> listUserId, T msg) {
            if (listUserId.Count == 0) {
                return;
            }

            IMessage data = (IMessage)(object)msg;
            byte[] msgIdByte = BitConverter.GetBytes(MsgType.getTypeId(msg.GetType()));
            byte[] msgByte = data.ToByteArray();
            byte[] sendByte = new byte[msgByte.Length + 2];
            msgIdByte.CopyTo(sendByte, 0);
            msgByte.CopyTo(sendByte, 2);

            foreach (uint userId in listUserId) {
                IPEndPoint pGroupEp = UserServer.Instance.getIpEndPointByUserId(userId);
                if (pGroupEp == null) {
                    return;
                }
                sendMsg2Client(pGroupEp, sendByte);
            }
        }

        private void Update() {
            mutex.WaitOne();
            m_waitHandleMasterList = new List<WaitHandler>(m_waitHandleSyncList);
            m_waitHandleSyncList.Clear();
            mutex.ReleaseMutex();
            foreach (WaitHandler waitHandler in m_waitHandleMasterList) {
                try {
                    ushort msgId = BitConverter.ToUInt16(waitHandler.m_bytes.Skip(0).Take(2).ToArray(), 0);
                    byte[] msgInfo = waitHandler.m_bytes.Skip(2).Take(waitHandler.m_bytes.Length - 2).ToArray();

                    if (m_onIpRevDic.ContainsKey(msgId)) {
                        m_onIpRevDic[msgId](msgInfo, waitHandler.m_groupEP);
                    }
                    if (m_onUserRevDic.ContainsKey(msgId)) {
                        uint userId = UserServer.Instance.getUserIdByIPEndPoint(waitHandler.m_groupEP);
                        try {
                            m_onUserRevDic[msgId](msgInfo, userId);
                        } catch (InvalidProtocolBufferException e) {
                            ServerLog.log(e.Message);
                        }
                    }
                } catch (SocketException e) {
                    ServerLog.log(e.Message);
                }
            }
            m_waitHandleMasterList.Clear();
        }

        float m_lastNatTime;

        //此为登录流程专用
        public void registerC2S(Type type, OnIpRev onRev) {
            ushort msgId = MsgType.getTypeId(type);
            if (m_onIpRevDic.ContainsKey(msgId)) {
                m_onIpRevDic[msgId] = onRev;
            } else {
                m_onIpRevDic.Add(msgId, onRev);
            }
        }

        //此为正常的服务端消息注册
        public void registerC2S(Type type, OnUserRev onUserRev) {
            ushort msgId = MsgType.getTypeId(type);
            if (m_onUserRevDic.ContainsKey(msgId)) {
                m_onUserRevDic[msgId] = onUserRev;
            } else {
                m_onUserRevDic.Add(msgId, onUserRev);
            }
        }
        private void OnDestroy() {
            ServerLog.log("OnDestroy");
            terminate();
        }

        private void OnApplicationQuit() {
            ServerLog.log("OnApplicationQuit");
            terminate();
        }

        public void terminate() {
            if (m_udpListenThread != null) {
                m_udpListenThread.Abort();
                m_udpListenThread = null;
            }
            if (m_listener != null) {
                m_listener.Close();
                m_listener = null;
            }
            m_serverIsRuning = false;
        }

        private void sendMsg2Client(IPEndPoint iPEndPoint, byte[] sendbuf) {
            m_listener.SendAsync(sendbuf, sendbuf.Length, iPEndPoint);
        }
    }
}
