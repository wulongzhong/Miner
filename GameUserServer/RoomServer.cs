using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameUserServer {

    class RoomData {
        public uint m_homeownerPlayerID;
        public IPEndPoint m_homeownerIP;
        public long m_createTime;
        public string m_roomName;
        public string m_password;
        //ToDo
    }

    class RoomServer : WF.SimpleComponent {
        public static RoomServer Instance;

        private const uint m_roomMaxCount = 1024;
        private uint m_roomIndex = 0;
        private Dictionary<uint, RoomData> m_dicRoomID2Data;

        public override bool initialize() {
            base.initialize();
            Instance = this;
            m_dicRoomID2Data = new Dictionary<uint, RoomData>();

            ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerRegisterRoomC2S), onUserServerRegisterRoomC2S);
            return true;
        }

        public void onUserServerRegisterRoomC2S(byte[] protoBytes, uint playerId) {

            MsgPB.UserServerRegisterRoomC2S msg = MsgPB.UserServerRegisterRoomC2S.Parser.ParseFrom(protoBytes);
            RoomData roomData = new RoomData();
            roomData.m_homeownerPlayerID = playerId;
            roomData.m_homeownerIP = PlayerServer.Instance.getIpEndPointByPlayerId(playerId);
            roomData.m_createTime = ServerMgr.Instance.NowTime;
            roomData.m_roomName = msg.MRoomName;
            roomData.m_password = msg.MPassword;
            ++m_roomIndex;
            m_dicRoomID2Data[m_roomIndex] = roomData;

        }
    }
}
