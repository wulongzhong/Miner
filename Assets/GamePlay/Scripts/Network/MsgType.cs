using System;
using System.Collections;
using System.Collections.Generic;

public static class MsgType {
    private static Dictionary<Type, int> m_msgType2IdDic = new Dictionary<Type, int>() {
        { typeof(MsgPB.GameCommandS2C), 1001},

    };

    public static int getTypeId(Type type) {
        if (m_msgType2IdDic.ContainsKey(type)) {
            return m_msgType2IdDic[type];
        }
        return 0;
    }
}
