using System.Collections;
using System.Collections.Generic;
using System.Net;

public class GameConfig {
    public static GameConfig Instance;

    public GameConfig() {
        Instance = this;
    }

    //缓存帧超过此值时开始追帧
    private const int m_chaseFrameCount = 2;
    //指令帧的缩放
    private const int m_frameScale = 2;
    //每次消息下发的帧数量
    private const int m_frameCommandCount = 1;
    //缓存帧数
    private const int m_cacheFrameCommandCount = 60 / m_frameScale * 10;
    //user server ip和端口
    private IPEndPoint m_userServerIpendPoint = new IPEndPoint(IPAddress.Parse("47.98.39.254"), 19982);
    // 心跳间隔时间
    private int m_heartBeatIntervalTime = 8000;
    // 心跳最大等待时间
    private int m_heartBeatWaitTime = 24000;
    //一次ping的间隔时间
    private long m_PingIntervalMS = 1000;
    //ping的最大等待时间
    private long m_PingMaxWaitMS = 5000;

    public int FrameScale { get => m_frameScale; }
    public int FrameCommandCount { get => m_frameCommandCount; }
    public int ChaseFrameCount { get => m_chaseFrameCount; }

    public int CacheFrameCommandCount { get => m_cacheFrameCommandCount; }
    public IPEndPoint UserServerIpendPoint { get => m_userServerIpendPoint; }
    public int HeartBeatIntervalTime { get => m_heartBeatIntervalTime;}
    public int HeartBeatWaitTime { get => m_heartBeatWaitTime;}
    public long PingIntervalMS { get => m_PingIntervalMS; set => m_PingIntervalMS = value; }
    public long PingMaxWaitMS { get => m_PingMaxWaitMS; set => m_PingMaxWaitMS = value; }
}