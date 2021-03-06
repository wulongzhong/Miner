using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace GameUserServer {
    class ServerMsgReceiver :WF.SimpleComponent {
        public delegate void OnIpRev(byte[] protobytes, IPEndPoint iPEndPoint);
        public delegate void OnPlayerRev(byte[] protobytes, uint roleId);
        public delegate void OnRoomrRev(byte[] protobytes, uint roomId);

        private const int m_listenPort = 19982;
        private UdpClient m_listener;
        private Thread m_udpListenThread;
        private bool m_serverIsRuning;

        public static ServerMsgReceiver Instance;

        private Dictionary<ushort, OnIpRev> m_onIpRevDic;
        private Dictionary<ushort, OnPlayerRev> m_onPlayerRevDic;
        private Dictionary<ushort, OnRoomrRev> m_onRoomrRev;

        public static Mutex mutex = new Mutex();
        class WaitHandler {
            public byte[] m_bytes;
            public IPEndPoint m_groupEP;
        }
        private List<WaitHandler> m_waitHandleSyncList;
        private List<WaitHandler> m_waitHandleMasterList;

        public override bool initialize() {
            base.initialize();
            Instance = this;
            m_onIpRevDic = new Dictionary<ushort, OnIpRev>();
            m_onPlayerRevDic = new Dictionary<ushort, OnPlayerRev>();
            m_onRoomrRev = new Dictionary<ushort, OnRoomrRev>();
            m_waitHandleSyncList = new List<WaitHandler>();
            m_waitHandleMasterList = new List<WaitHandler>();
            startUdpListen();
            return true;
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

        //对房间发送消息
        public void sendMsgToRoom<T>(uint roomId, T msg) {
            IPEndPoint pGroupEp = RoomServer.Instance.getIpEndPointByRoomId(roomId);
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

        //对单个玩家发送消息
        public void sendMsgToPlayer<T>(uint playerId, T msg) {
            IPEndPoint pGroupEp = PlayerServer.Instance.getIpEndPointByPlayerId(playerId);
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
        public void sendMsgToPlayer<T>(List<uint> listPlayerId, T msg) {
            if (listPlayerId.Count == 0) {
                return;
            }

            IMessage data = (IMessage)(object)msg;
            byte[] msgIdByte = BitConverter.GetBytes(MsgType.getTypeId(msg.GetType()));
            byte[] msgByte = data.ToByteArray();
            byte[] sendByte = new byte[msgByte.Length + 2];
            msgIdByte.CopyTo(sendByte, 0);
            msgByte.CopyTo(sendByte, 2);

            foreach (uint playerId in listPlayerId) {
                IPEndPoint pGroupEp = PlayerServer.Instance.getIpEndPointByPlayerId(playerId);
                if (pGroupEp == null) {
                    continue;
                }
                sendMsg2Client(pGroupEp, sendByte);
            }
        }

        public override void update() {
            mutex.WaitOne();
            m_waitHandleMasterList = new List<WaitHandler>(m_waitHandleSyncList);
            m_waitHandleSyncList.Clear();
            mutex.ReleaseMutex();
            foreach (WaitHandler waitHandler in m_waitHandleMasterList) {
                try {
                    ushort msgId = BitConverter.ToUInt16(waitHandler.m_bytes.Skip(0).Take(2).ToArray(), 0);
                    byte[] msgInfo = waitHandler.m_bytes.Skip(2).Take(waitHandler.m_bytes.Length - 2).ToArray();
                    try {
                        if (m_onIpRevDic.ContainsKey(msgId)) {
                            m_onIpRevDic[msgId](msgInfo, waitHandler.m_groupEP);
                        }
                        if (m_onPlayerRevDic.ContainsKey(msgId)) {
                            uint playerId = PlayerServer.Instance.getPlayerIdByIPEndPoint(waitHandler.m_groupEP);
                                m_onPlayerRevDic[msgId](msgInfo, playerId);
                        
                        }
                    } catch (InvalidProtocolBufferException e) {
                        ServerLog.log(e.Message);
                    }
                } catch (SocketException e) {
                    ServerLog.log(e.Message);
                }
            }
            m_waitHandleMasterList.Clear();
        }

        //此为登录流程专用
        public void registerC2S(Type type, OnIpRev onRev) {
            ushort msgId = MsgType.getTypeId(type);
            if (msgId == 0) {
                ServerLog.log("msgId == 0");
            }
            if (m_onIpRevDic.ContainsKey(msgId)) {
                m_onIpRevDic[msgId] = onRev;
            } else {
                m_onIpRevDic.Add(msgId, onRev);
            }
        }

        //此为正常的服务端消息注册
        public void registerC2S(Type type, OnPlayerRev onPlayerRev) {
            ushort msgId = MsgType.getTypeId(type);
            if (m_onPlayerRevDic.ContainsKey(msgId)) {
                m_onPlayerRevDic[msgId] = onPlayerRev;
            } else {
                m_onPlayerRevDic.Add(msgId, onPlayerRev);
            }
        }

        //此为房间消息专用
        public void registerRS2S(Type type, OnRoomrRev onRoomrRev) {
            ushort msgId = MsgType.getTypeId(type);
            if (m_onRoomrRev.ContainsKey(msgId)) {
                m_onRoomrRev[msgId] = onRoomrRev;
            } else {
                m_onRoomrRev.Add(msgId, onRoomrRev);
            }
        }

        public override void terminate() {
            if (m_udpListenThread != null) {
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
