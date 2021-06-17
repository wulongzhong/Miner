using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerRoomHeartBeat : WF.SimpleComponent {
    public static HandlerRoomHeartBeat Instance;
    private float m_lastReceiveServerTime;
    private float m_lastSendTime;

    public override bool initialize() {
        base.initialize();
        Instance = this;

        m_lastReceiveServerTime = Time.time;
        m_lastSendTime = Time.time;

        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.GameRoomHeartBeatS2C), onGameRoomHeartBeatS2C);
        return true;
    }

    public void onGameRoomHeartBeatS2C(byte[] protobytes) {
        MsgPB.GameRoomHeartBeatS2C msg = MsgPB.GameRoomHeartBeatS2C.Parser.ParseFrom(protobytes);
        m_lastReceiveServerTime = Time.time;
    }

    bool m_bViewOffline = true;

    public override void update() {
        if (HandlerRoomPlayer.Instance.getSelf() == null) {
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
            MsgPB.GameRoomHeartBeatC2S msg = new MsgPB.GameRoomHeartBeatC2S();
            msg.MPlayerId = HandlerRoomPlayer.Instance.SelfPlayerId;
            msg.MKey = HandlerRoomPlayer.Instance.Key;
            ClientMsgReceiver.Instance.sendMsg2RoomServer(msg);
        }
    }
}