using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerMgr : WF.SimpleComponent {
    public override bool initialize() {
        ClientMsgReceiver clientMsgReceiver = new ClientMsgReceiver();
        clientMsgReceiver.initialize();
        addComponent(clientMsgReceiver);

        HandlerRoomCommandExecute handlerRoomCommandExecute = new HandlerRoomCommandExecute();
        handlerRoomCommandExecute.initialize();
        addComponent(handlerRoomCommandExecute);

        HandlerRoomCommandFactory handlerRoomCommandFactory = new HandlerRoomCommandFactory();
        handlerRoomCommandFactory.initialize();
        addComponent(handlerRoomCommandFactory);

        HandlerRoomDataCache handlerRoomDataCache = new HandlerRoomDataCache();
        handlerRoomDataCache.initialize();
        addComponent(handlerRoomDataCache);

        HandlerRoomHeartBeat handlerRoomHeartBeat = new HandlerRoomHeartBeat();
        handlerRoomHeartBeat.initialize();
        addComponent(handlerRoomHeartBeat);

        return true;
    }
}
