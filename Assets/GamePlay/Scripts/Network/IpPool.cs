using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class IpPool {

    private Dictionary<uint, IPEndPoint> m_dicUserId2IPEndPoint;
    private Dictionary<IPEndPoint, uint> m_dicIPEndPoint2UserId;

    public IpPool() {
        m_dicUserId2IPEndPoint = new Dictionary<uint, IPEndPoint>();
        m_dicIPEndPoint2UserId = new Dictionary<IPEndPoint, uint>();
    }


    public void addIpEndPoint(uint userId, IPEndPoint ipEndPoint) {
        m_dicUserId2IPEndPoint[userId] = ipEndPoint;
        m_dicIPEndPoint2UserId[ipEndPoint] = userId;
    }

    public IPEndPoint getIpEndPointByUserId(uint userId) {
        if (m_dicUserId2IPEndPoint.ContainsKey(userId)) {
            return m_dicUserId2IPEndPoint[userId];
        }
        return null;
    }

    public uint getUserIdByIPEndPoint(IPEndPoint ipEndPoint) {
        if (m_dicIPEndPoint2UserId.ContainsKey(ipEndPoint)) {
            return m_dicIPEndPoint2UserId[ipEndPoint];
        }
        return 0;
    }
}
