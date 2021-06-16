using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerHallPlayer : WF.SimpleComponent {
    public static HandlerHallPlayer Instance;
    public override bool initialize() {
        base.initialize();

        return true;
    }

    public void login() {
        MsgPB.UserServerPlayerLoginC2S msg = new MsgPB.UserServerPlayerLoginC2S();

    }

    public void onUserServerPlayerLoginS2C(byte[] protobytes) {

    }
}
