using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GameRoomConfig {
    public static GameRoomConfig Instance;

    public GameRoomConfig() {
        Instance = this;
    }

    private const int m_chaseFrameCount = 2;
    private const int m_frameScale = 2;
    private const int m_frameCommandCount = 1;
    private const int m_cacheFrameCommandCount = 60 / m_frameScale * 10;
    //private IPEndPoint m_userServerIpendPoint = new IPEndPoint(IPAddress.Parse("47.98.39.254"), 19982);
    private IPEndPoint m_userServerIpendPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 19982);

    public int FrameScale { get => m_frameScale; }
    public int FrameCommandCount { get => m_frameCommandCount; }
    public int ChaseFrameCount { get => m_chaseFrameCount; }

    public int CacheFrameCommandCount { get => m_cacheFrameCommandCount; }
    public IPEndPoint UserServerIpendPoint { get => m_userServerIpendPoint; }
}