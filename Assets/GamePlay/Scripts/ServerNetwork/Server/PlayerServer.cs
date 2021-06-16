using System.Collections;
using System.Collections.Generic;
using System.Net;

public class PlayerServer : WF.SimpleComponent {

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

        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.GameRoomPlayerLoginC2S), onGameRoomPlayerLoginC2S);
        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.GameRoomHeartBeatC2S), onGameRoomHeartBeatC2S);

        return true;
    }


    public List<uint> getAllPlayerId() {
        return new List<uint>(m_listPlayerIds);
    }

    public void onGameRoomPlayerLoginC2S(byte[] protobytes, IPEndPoint iPEndPoint) {
        MsgPB.GameRoomPlayerLoginC2S msg = MsgPB.GameRoomPlayerLoginC2S.Parser.ParseFrom(protobytes);
        addIpEndPoint(msg.MPlayerId, iPEndPoint);

        if(!(m_listPlayerIds.Contains(msg.MPlayerId))){
            m_listPlayerIds.Add(msg.MPlayerId);
        }
        m_dicPlayerId2Key[msg.MPlayerId] = m_random.Next(int.MinValue, int.MaxValue);
        m_dicPlayerId2HeartBeat[msg.MPlayerId] = ServerMgr.Instance.NowTime;
        //告知登录成功
        MsgPB.GameRoomPlayerLoginS2C loginMsg = new MsgPB.GameRoomPlayerLoginS2C();
        loginMsg.MLoginSuccess = true;
        loginMsg.MPlayerId = msg.MPlayerId;
        loginMsg.MKey = m_dicPlayerId2Key[msg.MPlayerId];
        ServerMsgReceiver.Instance.sendMsg(msg.MPlayerId, loginMsg);

        //发送缓存数据
        MsgPB.GameRoomCache roomCache = HandlerRoomDataCache.Instance.getGameRoomCache();
        ServerMsgReceiver.Instance.sendMsg(msg.MPlayerId, roomCache);

        //发送缓存数据之后的指令
        GameCommandSyncServer.Instance.syncCacheCommandToNewPlayer(msg.MPlayerId, roomCache.MFrameIndex);

        //在帧里加入添加玩家的指令
        GameCommandSyncServer.Instance.addPlayer(msg.MPlayerId);
    }

    public void onGameRoomHeartBeatC2S(byte[] protobytes, IPEndPoint iPEndPoint) {
        MsgPB.GameRoomHeartBeatC2S msg = MsgPB.GameRoomHeartBeatC2S.Parser.ParseFrom(protobytes);
        if (m_dicPlayerId2Key.ContainsKey(msg.MPlayerId)) {
            if(msg.MKey == m_dicPlayerId2Key[msg.MPlayerId]) {
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
        foreach(var keyValue in m_dicPlayerId2HeartBeat) {
            if((ServerMgr.Instance.NowTime - keyValue.Value) > 10000) {
                lstOfflinePlayerId.Add(keyValue.Key);
            }
        }

        foreach(var offlinePlayerId in lstOfflinePlayerId) {
            m_dicPlayerId2HeartBeat.Remove(offlinePlayerId);
            m_dicIPEndPoint2PlayerId.Remove(m_dicPlayerId2IPEndPoint[offlinePlayerId]);
            m_dicPlayerId2IPEndPoint.Remove(offlinePlayerId);
        }

        if((ServerMgr.Instance.NowTime - m_lastHeartBeatTime) > 2000) {
            m_lastHeartBeatTime = ServerMgr.Instance.NowTime;
            MsgPB.GameRoomHeartBeatS2C msg = new MsgPB.GameRoomHeartBeatS2C();
            ServerMsgReceiver.Instance.sendMsg(getAllPlayerId(), msg);
        }
    }
}