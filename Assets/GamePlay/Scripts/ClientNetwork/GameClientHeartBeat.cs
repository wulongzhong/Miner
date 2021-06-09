using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClientHeartBeat : MonoBehaviour {
    public static GameClientHeartBeat Instance;
    private float m_lastReceiveServerTime;
    private float m_lastSendTime;
    private void Awake() {
        Instance = this;
    }

    private void Start() {
        m_lastReceiveServerTime = Time.time;
        m_lastSendTime = Time.time;

        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.GameRoomHeartBeatS2C), onGameRoomHeartBeatS2C);
    }

    public void onGameRoomHeartBeatS2C(byte[] protobytes) {
        MsgPB.GameRoomHeartBeatS2C msg = MsgPB.GameRoomHeartBeatS2C.Parser.ParseFrom(protobytes);
    }

    private void Update() {
        //掉线了
        if((Time.time - m_lastReceiveServerTime) > 10.0f) {
            Debug.Log("掉线了");
        }

        if((Time.time - m_lastSendTime) > 3.0f) {
            MsgPB.GameRoomHeartBeatC2S msg = new MsgPB.GameRoomHeartBeatC2S();
            msg.MPlayerId = PlayerMgr.Instance.SelfPlayerId;
            msg.MKey = PlayerMgr.Instance.Key;
            ClientMsgReceiver.Instance.sendMsg(msg);
        }
    }
}
