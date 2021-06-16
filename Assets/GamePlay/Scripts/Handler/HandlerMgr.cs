using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerMgr : WF.SimpleComponent {
    public override bool initialize() {
        ClientMsgReceiver clientMsgReceiver = new ClientMsgReceiver();
        clientMsgReceiver.initialize();
        addComponent(clientMsgReceiver);

        HandlerHallPlayer handlerHallPlayer = new HandlerHallPlayer();
        handlerHallPlayer.initialize();
        addComponent(handlerHallPlayer);

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

        HandlerRoomPlayer handlerRoomPlayer = new HandlerRoomPlayer();
        handlerRoomPlayer.initialize();
        addComponent(handlerRoomPlayer);

        return true;
    }
}
