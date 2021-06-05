using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerServer : MonoBehaviour {

    public static PlayerServer Instance;

    List<uint> m_listPlayerIds;
    private Dictionary<uint, IPEndPoint> m_dicPlayerId2IPEndPoint;
    private Dictionary<IPEndPoint, uint> m_dicIPEndPoint2PlayerId;

    private void Awake() {
        Instance = this;
        m_listPlayerIds = new List<uint>();

        m_dicPlayerId2IPEndPoint = new Dictionary<uint, IPEndPoint>();
        m_dicIPEndPoint2PlayerId = new Dictionary<IPEndPoint, uint>();
    }

    private void Start() {
        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.GameRoomPlayerLogin), onGameRoomPlayerLogin);
    }


    public List<uint> getAllPlayerId() {
        return new List<uint>(m_listPlayerIds);
    }

    public void onGameRoomPlayerLogin(byte[] protobytes, IPEndPoint iPEndPoint) {
        MsgPB.GameRoomPlayerLogin msg = MsgPB.GameRoomPlayerLogin.Parser.ParseFrom(protobytes);
        addIpEndPoint(msg.MPlayerId, iPEndPoint);

        MsgPB.GameRoomDataSyncS2C dataSyncMsg = new MsgPB.GameRoomDataSyncS2C();
        foreach(var playerId in m_listPlayerIds) {
            var cacheData = GameRoomCacheServer.Instance.getPlayerCache(playerId);
            if(cacheData != null) {
                dataSyncMsg.MLstCachePlayer.Add(cacheData);
            } else {
                ServerLog.log("cacheData != null");
            }
        }
        ServerMsgReceiver.Instance.sendMsg(msg.MPlayerId, dataSyncMsg);

        m_listPlayerIds.Add(msg.MPlayerId);
        GameCommandSyncServer.Instance.addPlayer(msg.MPlayerId);
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
}
