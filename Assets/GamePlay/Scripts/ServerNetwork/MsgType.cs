using System;
using System.Collections;
using System.Collections.Generic;

public static class MsgType {
    private static Dictionary<Type, ushort> m_msgType2IdDic = new Dictionary<Type, ushort>() {
        { typeof(MsgPB.GameCommandInfo), 1001},
        { typeof(MsgPB.GameCommandS2C), 1002},
        { typeof(MsgPB.GameRoomPlayerLogin), 1003},
        { typeof(MsgPB.GameRoomDataSyncS2C), 1004},
    };

    public static ushort getTypeId(Type type) {
        if (m_msgType2IdDic.ContainsKey(type)) {
            return m_msgType2IdDic[type];
        }
        return 0;
    }
}
