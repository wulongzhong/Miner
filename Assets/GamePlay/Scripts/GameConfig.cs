using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GameConfig {
    public static GameConfig Instance;

    public GameConfig() {
        Instance = this;
    }

    /// <summary>
    ///缓存帧超过此值时开始追帧
    /// </summary>
    private const int m_chaseFrameCount = 2;

    /// <summary>
    ///指令帧的缩放
    /// <summary>
    private const int m_frameScale = 2;

    /// <summary>
    ///每次消息下发的帧数量
    /// <summary>
    private const int m_frameCommandCount = 1;

    /// <summary>
    ///缓存帧数
    /// <summary>
    private const int m_cacheFrameCommandCount = 60 / m_frameScale * 10;

    /// <summary>
    ///user server ip和端口
    /// <summary>
    private IPEndPoint m_userServerIpendPoint = new IPEndPoint(IPAddress.Parse("47.98.39.254"), 19982);

    /// <summary>
    /// 心跳间隔时间
    /// </summary>
    private int m_heartBeatIntervalTime = 8000;

    /// <summary>
    /// 心跳最大等待时间
    /// </summary>
    private int m_heartBeatWaitTime = 24000;

    public int FrameScale { get => m_frameScale; }
    public int FrameCommandCount { get => m_frameCommandCount; }
    public int ChaseFrameCount { get => m_chaseFrameCount; }

    public int CacheFrameCommandCount { get => m_cacheFrameCommandCount; }
    public IPEndPoint UserServerIpendPoint { get => m_userServerIpendPoint; }
    public int HeartBeatIntervalTime { get => m_heartBeatIntervalTime;}
    public int HeartBeatWaitTime { get => m_heartBeatWaitTime;}
}