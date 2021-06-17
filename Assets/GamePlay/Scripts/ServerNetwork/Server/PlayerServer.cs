using System.Collections;
using System.Collections.Generic;
using System.Net;

public class PlayerServer : WF.SimpleComponent {

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

    public override bool initialize() {
        base.initialize();
        Instance = this;

        m_random = new System.Random((int)ServerMgr.Instance.NowTime);
        m_dicPlayerInfo = new Dictionary<uint, PlayerNetInfo>();
        m_dicIPEndPoint2PlayerInfo = new Dictionary<IPEndPoint, PlayerNetInfo>();

        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.GameRoomPlayerLoginC2S), onGameRoomPlayerLoginC2S);
        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.GameRoomHeartBeatC2S), onGameRoomHeartBeatC2S);

        return true;
    }


    public List<uint> getAllPlayerId() {
        List<uint> m_playerIds = new List<uint>();
        foreach (var playerInfo in m_dicIPEndPoint2PlayerInfo.Values) {
            m_playerIds.Add(playerInfo.m_playerID);
        }
        return m_playerIds;
    }

    public void onGameRoomPlayerLoginC2S(byte[] protobytes, IPEndPoint iPEndPoint) {
        MsgPB.GameRoomPlayerLoginC2S msg = MsgPB.GameRoomPlayerLoginC2S.Parser.ParseFrom(protobytes);

        if (!m_dicPlayerInfo.ContainsKey(msg.MPlayerId)) {
            m_dicPlayerInfo.Add(msg.MPlayerId, new PlayerNetInfo());
        }

        PlayerNetInfo playerNetInfo = m_dicPlayerInfo[msg.MPlayerId];
        playerNetInfo.m_key = m_random.Next(int.MinValue, int.MaxValue);
        playerNetInfo.m_lastHeartBeatTime = ServerMgr.Instance.NowTime;

        m_dicIPEndPoint2PlayerInfo[playerNetInfo.m_ipEndPoint] = playerNetInfo;

        //告知登录成功
        MsgPB.GameRoomPlayerLoginS2C loginMsg = new MsgPB.GameRoomPlayerLoginS2C();
        loginMsg.MLoginSuccess = true;
        loginMsg.MPlayerId = msg.MPlayerId;
        loginMsg.MKey = playerNetInfo.m_key;
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
        foreach(var keyValue in m_dicPlayerInfo) {
            if((ServerMgr.Instance.NowTime - keyValue.Value.m_lastHeartBeatTime) > GameConfig.Instance.HeartBeatWaitTime) {
                m_dicIPEndPoint2PlayerInfo.Remove(keyValue.Value.m_ipEndPoint);
                keyValue.Value.m_ipEndPoint = null;
            }
        }

        if((ServerMgr.Instance.NowTime - m_lastHeartBeatTime) > GameConfig.Instance.HeartBeatIntervalTime) {
            m_lastHeartBeatTime = ServerMgr.Instance.NowTime;
            MsgPB.GameRoomHeartBeatS2C msg = new MsgPB.GameRoomHeartBeatS2C();
            ServerMsgReceiver.Instance.sendMsg(getAllPlayerId(), msg);
        }
    }
}