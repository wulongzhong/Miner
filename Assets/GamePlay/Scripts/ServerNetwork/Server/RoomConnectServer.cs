using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class RoomConnectServer : WF.SimpleComponent {
    public static RoomConnectServer Instance;
    private uint m_roomID;
    private Dictionary<uint, IpEndPointPing> m_dicPingData;

    public uint RoomID { get => m_roomID; }

    public override bool initialize() {
        base.initialize();
        Instance = this;
        m_dicPingData = new Dictionary<uint, IpEndPointPing>();

        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerRegisterRoomS2RS), onUserServerRegisterRoomS2RS);
        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerJoinRoomS2RS), onUserServerJoinRoomS2RS);
        return true;
    }

    public override void update() {
        List<uint> listTimeLongPlayer = new List<uint>();
        foreach(var keyValue in m_dicPingData) {
            if(keyValue.Value.ping() == IpEndPointPing.PingState.TIME_LONG) {
                listTimeLongPlayer.Add(keyValue.Key);
            }
        }

        foreach(var playerId in listTimeLongPlayer) {
            m_dicPingData.Remove(playerId);
        }
    }

    public void registerRoom() {
        MsgPB.UserServerRegisterRoomC2S msg = new MsgPB.UserServerRegisterRoomC2S();
        msg.MRoomName = "hhh";
        ServerMsgReceiver.Instance.sendMsgToUserServer(msg);
    }

    public void onUserServerRegisterRoomS2RS(byte[] protobytes) {
        MsgPB.UserServerRegisterRoomS2RS msg = MsgPB.UserServerRegisterRoomS2RS.Parser.ParseFrom(protobytes);
        m_roomID = msg.MRoomID;
        ServerLog.log("register success, room Id : " + m_roomID);
    }

    public void onUserServerJoinRoomS2RS(byte[] protobytes) {
        MsgPB.UserServerJoinRoomS2RS msg = MsgPB.UserServerJoinRoomS2RS.Parser.ParseFrom(protobytes);
        IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(msg.MIp), (int)msg.MPort);
        m_dicPingData[msg.MPlayerId] = new IpEndPointPing(msg.MPlayerId, iPEndPoint);
    }

    public void onCommonPingA2A(byte[] protobytes, IPEndPoint iPEndPoint) {
        uint playerId = 0;
        foreach(var keyValue in m_dicPingData) {
            if(keyValue.Value.m_ipendPoint == iPEndPoint) {
                playerId = keyValue.Key;
            }
        }
        if(playerId != 0) {
            m_dicPingData.Remove(playerId);
        }
    }
}
