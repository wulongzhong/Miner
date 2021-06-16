﻿using System.Collections;
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
    private void Update() {
        if (PlayerMgr.Instance.getSelf() == null) {
            return;
        }

        //掉线了
        if ((Time.time - m_lastReceiveServerTime) > 10.0f) {
            if (m_bViewOffline) {
                Debug.Log("掉线了");
                m_bViewOffline = false;
            }
        }

        if((Time.time - m_lastSendTime) > 2.0f) {
            m_lastSendTime = Time.time;
            MsgPB.GameRoomHeartBeatC2S msg = new MsgPB.GameRoomHeartBeatC2S();
            msg.MPlayerId = PlayerMgr.Instance.SelfPlayerId;
            msg.MKey = PlayerMgr.Instance.Key;
            ClientMsgReceiver.Instance.sendMsg(msg);
        }
    }
}