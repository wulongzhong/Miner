using System;
using System.Collections;
using System.Collections.Generic;

public static class MsgType {
    private static List<Type> m_lstMsgType = new List<Type>() {

    };

    public static ushort getTypeId(Type type) {
        if (m_lstMsgType.Contains(type)) {
            return (ushort)(m_lstMsgType.IndexOf(type) + 1);
        }
        return 0;
    }
}
