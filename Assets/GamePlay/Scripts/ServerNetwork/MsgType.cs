using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MsgType {
    private static List<Type> m_lstMsgType = new List<Type>() {
        typeof(MsgPB.GameRoomPlayerLoginC2S),
        typeof(MsgPB.GameRoomPlayerLoginS2C),
        
        typeof(MsgPB.GameRoomHeartBeatC2S),
        typeof(MsgPB.GameRoomHeartBeatS2C),

        typeof(MsgPB.GameRoomCache),

        typeof(MsgPB.GameCommandInfo),
        typeof(MsgPB.GameCommandRetrieveC2S),
        typeof(MsgPB.GameCommandRetrieveErrorS2C),
        typeof(MsgPB.GameCommandS2C),
        typeof(MsgPB.GameFrameAllCommandInfo),
    };

    public static ushort getTypeId(Type type) {
        if (m_lstMsgType.Contains(type)) {
            return (ushort)(m_lstMsgType.IndexOf(type) + 1);
        }
        Debug.LogError("type null");
        return 0;
    }
}
