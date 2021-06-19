using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class IpEndPointPing {

    public enum PingState {
        NONE = 0,
        TIME_LONG = 1,
    }

    public uint m_playerId;
    public IPEndPoint m_ipendPoint;
    private long m_startPingTime;
    private long m_lastPingTime;
    public IpEndPointPing(uint playerId, IPEndPoint iPEndPoint) {
        m_startPingTime = ServerMgr.Instance.NowTime;
        m_playerId = playerId;
        m_ipendPoint = iPEndPoint;
        ping();
    }

    public PingState ping() {
        if((ServerMgr.Instance.NowTime - m_startPingTime) > GameConfig.Instance.PingMaxWaitMS) {
            return PingState.TIME_LONG;
        }

        if((ServerMgr.Instance.NowTime - m_lastPingTime) >= GameConfig.Instance.PingIntervalMS) {
            m_lastPingTime = ServerMgr.Instance.NowTime;
            ServerMsgReceiver.Instance.sendMsgToIpEndPoint(m_ipendPoint, new MsgPB.CommonPingA2A());
        }
        return PingState.NONE;
    }
}
