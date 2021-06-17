using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerHallHeartBeat : WF.SimpleComponent {
    public static HandlerHallHeartBeat Instance;
    private float m_lastReceiveServerTime;
    private float m_lastSendTime;

    public override bool initialize() {
        base.initialize();
        Instance = this;

        m_lastReceiveServerTime = Time.time;
        m_lastSendTime = Time.time;

        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.UserServerHeartBeatS2C), onUserServerHeartBeatS2C);
        return true;
    }

    public void onUserServerHeartBeatS2C(byte[] protobytes) {
        MsgPB.UserServerHeartBeatS2C msg = MsgPB.UserServerHeartBeatS2C.Parser.ParseFrom(protobytes);
        m_lastReceiveServerTime = Time.time;
        Debug.Log("收到服务器心跳包 Time : " + Time.time);
    }

    bool m_bViewOffline = true;

    public override void update() {
        if (HandlerHallPlayer.Instance.SelfPlayerId == 0) {
            return;
        }

        //掉线了
        if ((Time.time - m_lastReceiveServerTime) > (GameConfig.Instance.HeartBeatWaitTime * 0.001f)) {
            if (m_bViewOffline) {
                Debug.Log("与游戏房间失去连接");
                m_bViewOffline = false;
            }
        }

        if ((Time.time - m_lastSendTime) > (GameConfig.Instance.HeartBeatIntervalTime * 0.001f)) {
            m_lastSendTime = Time.time;
            MsgPB.UserServerHeartBeatC2S msg = new MsgPB.UserServerHeartBeatC2S();
            msg.MPlayerId = HandlerHallPlayer.Instance.SelfPlayerId;
            msg.MKey = HandlerHallPlayer.Instance.Key;
            ClientMsgReceiver.Instance.sendMsg2UserServer(msg);
        }
    }
}
