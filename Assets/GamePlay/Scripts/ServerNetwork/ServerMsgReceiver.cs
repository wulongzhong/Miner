using Google.Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class ServerMsgReceiver : MonoBehaviour
{
    public delegate void OnIpRev(byte[] protobytes, IPEndPoint iPEndPoint);
    public delegate void OnPlayerRev(byte[] protobytes, uint roleId);

    private const int m_listenPort = 19981;
    private UdpClient m_listener;
    private Thread m_udpListenThread;
    private bool m_serverIsRuning;

    public static ServerMsgReceiver Instance;

    private Dictionary<int, OnIpRev> m_onIpRevDic;
    private Dictionary<int, OnPlayerRev> m_onPlayerRevDic;

    private IpPool m_ipPool;

    public static Mutex mutex = new Mutex();
    class WaitHandler {
        public byte[] m_bytes;
        public IPEndPoint m_groupEP;
    }
    private List<WaitHandler> m_waitHandleSyncList;
    private List<WaitHandler> m_waitHandleMasterList;

    private void Awake() {
        Instance = this;
    }

    public void open() {
        m_onIpRevDic = new Dictionary<int, OnIpRev>();
        m_onPlayerRevDic = new Dictionary<int, OnPlayerRev>();
        m_waitHandleSyncList = new List<WaitHandler>();
        m_waitHandleMasterList = new List<WaitHandler>();
        m_ipPool = new IpPool();
        startUdpListen();
    }

    public void close() {
        terminate();
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
    public void sendMsg<T>(uint playerId, T msg) {
        IPEndPoint pGroupEp = m_ipPool.getIpEndPointByPlayerId(playerId);
        if (pGroupEp == null) {
            return;
        }
        IMessage data = (IMessage)(object)msg;
        byte[] msgIdByte = BitConverter.GetBytes(MsgType.getTypeId(msg.GetType()));
        byte[] msgByte = data.ToByteArray();
        byte[] sendByte = new byte[msgByte.Length + 4];
        msgIdByte.CopyTo(sendByte, 0);
        msgByte.CopyTo(sendByte, 4);
        sendMsg2Client(pGroupEp, sendByte);
    }
    //对多个玩家发送消息
    public void sendMsg<T>(List<uint> listPlayerId, T msg) {
        if(listPlayerId.Count == 0) {
            return;
        }

        IMessage data = (IMessage)(object)msg;
        byte[] msgIdByte = BitConverter.GetBytes(MsgType.getTypeId(msg.GetType()));
        byte[] msgByte = data.ToByteArray();
        byte[] sendByte = new byte[msgByte.Length + 4];
        msgIdByte.CopyTo(sendByte, 0);
        msgByte.CopyTo(sendByte, 4);

        foreach(uint playerId in listPlayerId) {
            IPEndPoint pGroupEp = m_ipPool.getIpEndPointByPlayerId(playerId);
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
                int msgId = BitConverter.ToInt32(waitHandler.m_bytes.Skip(0).Take(4).ToArray(), 0);
                byte[] msgInfo = waitHandler.m_bytes.Skip(4).Take(waitHandler.m_bytes.Length - 4).ToArray();

                if (m_onIpRevDic.ContainsKey(msgId)) {
                    m_onIpRevDic[msgId](msgInfo, waitHandler.m_groupEP);
                }
                if (m_onPlayerRevDic.ContainsKey(msgId)) {
                    uint playerId = m_ipPool.getPlayerIdByIPEndPoint(waitHandler.m_groupEP);
                    try {
                        m_onPlayerRevDic[msgId](msgInfo, playerId);
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

    //此为登录流程专用
    public void registerC2S(Type type, OnIpRev onRev) {
        int msgId = MsgType.getTypeId(type);
        if (m_onIpRevDic.ContainsKey(msgId)) {
            m_onIpRevDic[msgId] = onRev;
        } else {
            m_onIpRevDic.Add(msgId, onRev);
        }
    }

    //此为正常的服务端消息注册
    public void registerC2S(Type type, OnPlayerRev onPlayerRev) {
        int msgId = MsgType.getTypeId(type);
        if (m_onPlayerRevDic.ContainsKey(msgId)) {
            m_onPlayerRevDic[msgId] = onPlayerRev;
        } else {
            m_onPlayerRevDic.Add(msgId, onPlayerRev);
        }
    }
    private void OnDestroy() {
        Debug.Log("OnDestroy");
        terminate();
    }

    private void OnApplicationQuit() {
        Debug.Log("OnApplicationQuit");
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
