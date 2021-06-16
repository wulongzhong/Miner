using System;
using System.Collections;
using System.Collections.Generic;

public static class MsgType {
    private static List<Type> m_lstMsgType = new List<Type>() {
        //user server包含的
        typeof(MsgPB.UserServerPlayerLoginC2S),
        typeof(MsgPB.UserServerPlayerLoginS2C),

        typeof(MsgPB.UserServerHeartBeatC2S),
        typeof(MsgPB.UserServerHeartBeatS2C),

        //user server不包含的
#if !USER_SERVER
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
#endif
    };

    public static ushort getTypeId(Type type) {
        if (m_lstMsgType.Contains(type)) {
            return (ushort)(m_lstMsgType.IndexOf(type) + 1);
        }
        return 0;
    }
}
