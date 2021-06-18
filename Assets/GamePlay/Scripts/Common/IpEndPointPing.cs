using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class IpEndPointPing {

    public enum PingState {
        NONE = 0,
        TIME_LONG = 1,
    }

    private const long m_intervalMS = 1000;
    private const long m_maxPingTime = 6000;

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
        if((ServerMgr.Instance.NowTime - m_startPingTime) > m_maxPingTime) {
            return PingState.TIME_LONG;
        }

        if((ServerMgr.Instance.NowTime - m_lastPingTime) >= m_intervalMS) {
            m_lastPingTime = ServerMgr.Instance.NowTime;
            ServerMsgReceiver.Instance.sendMsgByIpEndPoint(m_ipendPoint, new MsgPB.CommonPingA2A());
        }
        return PingState.NONE;
    }
}
