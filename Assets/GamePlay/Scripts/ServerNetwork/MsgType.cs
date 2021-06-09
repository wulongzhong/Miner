using System;
using System.Collections;
using System.Collections.Generic;

public static class MsgType {
    private static List<Type> m_lstMsgType = new List<Type>() {
        typeof(MsgPB.GameCommandInfo),
        typeof(MsgPB.GameCommandRetrieveC2S),
        typeof(MsgPB.GameCommandRetrieveErrorS2C),
        typeof(MsgPB.GameCommandS2C),
        typeof(MsgPB.GameRoomPlayerLogin),
        typeof(MsgPB.GameRoomCache),
    };

    public static ushort getTypeId(Type type) {
        if (m_lstMsgType.Contains(type)) {
            return (ushort)m_lstMsgType.IndexOf(type);
        }
        return 0;
    }
}
