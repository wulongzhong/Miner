using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class RoomConnectServer : WF.SimpleComponent {
    public static RoomConnectServer Instance;
    Dictionary<uint, IpEndPointPing> m_dicPingData;

    public override bool initialize() {
        base.initialize();
        Instance = this;
        m_dicPingData = new Dictionary<uint, IpEndPointPing>();
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
        msg.MPassword = "";
        ServerMsgReceiver.Instance.sendMsgByIpEndPoint(GameConfig.Instance.UserServerIpendPoint, msg);
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
