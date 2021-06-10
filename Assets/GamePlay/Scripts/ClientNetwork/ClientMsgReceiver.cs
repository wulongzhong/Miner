using Google.Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

public class ClientMsgReceiver : MonoBehaviour {
    public static ClientMsgReceiver Instance;

    public delegate void OnRev(byte[] protobytes);
    private Dictionary<ushort, OnRev> m_onRevDic;

    public static Mutex mutex = new Mutex();
    private List<byte[]> m_waitHandleSyncList;
    private List<byte[]> m_waitHandleMasterList;

    private string m_serverIpAddr = "127.0.0.1";

    private UdpClient m_listener;
    private IPEndPoint m_groupEP;
    private Thread m_udpListenThread;
    private bool m_serverIsRuning;

    //public string ServerIpAddr { get => m_serverIpAddr; set => m_serverIpAddr = value; }

    private void Awake() {
        Instance = this;
        //实例化成员变量
        gameObject.SetActive(true);
        m_onRevDic = new Dictionary<ushort, OnRev>();
        m_waitHandleSyncList = new List<byte[]>();
        m_waitHandleMasterList = new List<byte[]>();
    }

    public void startUdp() {
        terminate();
        m_serverIsRuning = true;
        m_serverIpAddr = GamePlay.Instance.ServerIpAddr;
        m_listener = new UdpClient();
        //IPAddress broadcast = IPAddress.Parse("47.98.39.254");
        IPAddress broadcast = IPAddress.Parse(m_serverIpAddr);
        m_listener.Connect(broadcast, GamePlay.Instance.ServerPort);
        //开启新线程接收新消息
        m_udpListenThread = new Thread(UdpListenUpdate);
        m_udpListenThread.Start();
    }

    public void UdpListenUpdate() {
        try {
            while (m_serverIsRuning) {
                byte[] bytes = m_listener.Receive(ref m_groupEP);
                mutex.WaitOne();
                m_waitHandleSyncList.Add(bytes);
                mutex.ReleaseMutex();
            }
        } catch (SocketException e) {
            ServerLog.log(e.Message);
            ServerLog.log("Client Connect Server Fail");
        } finally {
            startUdp();
        }
    }

    private void Update() {
        mutex.WaitOne();
        m_waitHandleMasterList = new List<byte[]>(m_waitHandleSyncList);
        m_waitHandleSyncList.Clear();
        mutex.ReleaseMutex();
        foreach (byte[] bytes in m_waitHandleMasterList) {
            try {
                ushort msgId = BitConverter.ToUInt16(bytes.Skip(0).Take(2).ToArray(), 0);
                byte[] msgInfo = bytes.Skip(2).Take(bytes.Length - 2).ToArray();
                if (m_onRevDic.ContainsKey(msgId)) {
                    try {
                        m_onRevDic[msgId](msgInfo);
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

    private void OnDestroy() {
        terminate();
    }

    private void OnApplicationQuit() {
        terminate();
    }

    private void terminate() {
        m_waitHandleSyncList = new List<byte[]>();
        m_waitHandleMasterList = new List<byte[]>();

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

    public void registerS2C(Type type, OnRev onRev) {
        ushort msgId = MsgType.getTypeId(type);
        if (m_onRevDic.ContainsKey(msgId)) {
            m_onRevDic[msgId] = onRev;
        } else {
            m_onRevDic.Add(msgId, onRev);
        }
    }

    public void sendMsg<T>(T msg) {
        IMessage data = (IMessage)(object)msg;
        byte[] msgIdByte = BitConverter.GetBytes(MsgType.getTypeId(msg.GetType()));
        byte[] msgByte = data.ToByteArray();
        byte[] sendByte = new byte[msgByte.Length + 2];
        Debug.Log("sendByte length : " + sendByte.Length);
        msgIdByte.CopyTo(sendByte, 0);
        msgByte.CopyTo(sendByte, 2);
        sendMsg2Server(sendByte);
    }

    private void sendMsg2Server(byte[] sendbuf) {
        if (m_listener == null) {
            ServerLog.log("Client Connect Server Fail");
            return;
        }
        try {
            m_listener.SendAsync(sendbuf, sendbuf.Length);
        } catch (SocketException e) {
            ServerLog.log(e.Message);
            if(e.ErrorCode == (int)SocketError.NotConnected) {
                startUdp();
            }
        }
    }
}
