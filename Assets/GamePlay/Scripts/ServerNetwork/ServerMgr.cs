using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerMgr : WF.SimpleComponent {
    public override bool initialize() {
        base.initialize();

        ServerMsgReceiver serverMsgReceiver = new ServerMsgReceiver();
        serverMsgReceiver.initialize();
        addComponent(serverMsgReceiver);

        PlayerServer playerServer = new PlayerServer();
        playerServer.initialize();
        addComponent(playerServer);

        GameCommandSyncServer gameCommandSyncServer = new GameCommandSyncServer();
        gameCommandSyncServer.initialize();
        addComponent(gameCommandSyncServer);

        return true;
    }
}
