using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class IpPool {

    private Dictionary<uint, IPEndPoint> m_dicPlayerId2IPEndPoint;
    private Dictionary<IPEndPoint, uint> m_dicIPEndPoint2PlayerId;

    public IpPool() {
        m_dicPlayerId2IPEndPoint = new Dictionary<uint, IPEndPoint>();
        m_dicIPEndPoint2PlayerId = new Dictionary<IPEndPoint, uint>();
    }


    public void addIpEndPoint(uint playerId, IPEndPoint ipEndPoint) {
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
