using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameUserServer {

    class RoomInfo {
        public uint m_homeownerPlayerID;
        public IPEndPoint m_homeownerIP;
        public long m_createTime;
        //ToDo
    }

    class RoomServer : WF.SimpleComponent {
        public static RoomServer Instance;

        private Dictionary<uint, RoomInfo> m_dicRoomID2Info;

        public override bool initialize() {
            base.initialize();
            Instance = this;
            m_dicRoomID2Info = new Dictionary<uint, RoomInfo>();

            ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerRegisterRoomC2S), onUserServerRegisterRoomC2S);
            return true;
        }

        public void onUserServerRegisterRoomC2S(byte[] protoBytes, uint playerId) {

        }
    }
}
