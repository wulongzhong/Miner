using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerHallPlayer : WF.SimpleComponent {
    public static HandlerHallPlayer Instance;

    private uint m_selfPlayerId;
    private long m_key;

    public uint SelfPlayerId { get => m_selfPlayerId; }
    public long Key { get => m_key; }

    public override bool initialize() {
        base.initialize();

        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.UserServerPlayerLoginS2C), onUserServerPlayerLoginS2C);

        //ToDo
        login();
        return true;
    }

    public void login() {
        MsgPB.UserServerPlayerLoginC2S msg = new MsgPB.UserServerPlayerLoginC2S();
        ClientMsgReceiver.Instance.sendMsg2UserServer(msg);
    }

    public void onUserServerPlayerLoginS2C(byte[] protobytes) {
        MsgPB.UserServerPlayerLoginS2C msg = MsgPB.UserServerPlayerLoginS2C.Parser.ParseFrom(protobytes);
        HandlerRoomPlayer.Instance.SelfPlayerId = msg.MPlayerId;
        m_selfPlayerId = msg.MPlayerId;
        m_key = msg.MKey;
    }
}
