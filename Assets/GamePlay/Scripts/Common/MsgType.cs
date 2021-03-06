using System;
using System.Collections;
using System.Collections.Generic;

public static class MsgType {

    private static ushort m_maxUserServerMsgID = 0;
    private static List<Type> m_lstMsgType = new List<Type>() {
        //user server包含的
        typeof(MsgPB.CommonPingA2A),

        typeof(MsgPB.UserServerPlayerLoginC2S),
        typeof(MsgPB.UserServerPlayerLoginS2C),

        typeof(MsgPB.UserServerHeartBeatC2S),
        typeof(MsgPB.UserServerHeartBeatS2C),
        typeof(MsgPB.UserServerRoomHeartBeatRS2S),
        typeof(MsgPB.UserServerRoomHeartBeatS2RS),

        typeof(MsgPB.UserServerRegisterRoomC2S),
        typeof(MsgPB.UserServerRegisterRoomS2RS),

        typeof(MsgPB.UserServerFindRoomC2S),
        typeof(MsgPB.UserServerFindRoomS2C),

        typeof(MsgPB.UserServerJoinRoomC2S),
        typeof(MsgPB.UserServerJoinRoomS2C),
        typeof(MsgPB.UserServerJoinRoomS2RS),

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

    public static ushort getMaxUserServerMsg() {
        if(m_maxUserServerMsgID == 0) {
            m_maxUserServerMsgID = (ushort)(m_lstMsgType.IndexOf(typeof(MsgPB.UserServerJoinRoomS2RS)) + 1);
        }
        return m_maxUserServerMsgID;
    }
}
