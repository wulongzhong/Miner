using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomConnectServer : WF.SimpleComponent {
    public override bool initialize() {
        base.initialize();

        return true;
    }

    public override void update() {
        base.update();
    }

    public void onUserServerJoinRoomS2RS(byte[] protobytes) {

    }
}
