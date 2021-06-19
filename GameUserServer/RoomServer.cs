﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameUserServer {

    class RoomData {
        public uint m_roomId;
        public uint m_homeownerPlayerID;
        public long m_key;
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
            ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.UserServerFindRoomC2S), onUserServerFindRoomC2S);
            return true;
        }

        public IPEndPoint getIpEndPointByRoomId(uint roomId) {
            if (m_dicRoomID2Data.ContainsKey(roomId)) {
                return m_dicRoomID2Data[roomId].m_homeownerIP;
            }
            return null;
        }

        public void onUserServerRegisterRoomC2S(byte[] protoBytes, IPEndPoint iPEndPoint) {
            MsgPB.UserServerRegisterRoomC2S msg = MsgPB.UserServerRegisterRoomC2S.Parser.ParseFrom(protoBytes);

            if(!PlayerServer.Instance.checkPlayerKey(msg.MPlayerId, msg.MKey)) {
                return;
            }

            ++m_roomIndex;
            RoomData roomData = new RoomData();
            roomData.m_roomId = m_roomIndex;
            roomData.m_homeownerPlayerID = msg.MPlayerId;
            roomData.m_homeownerIP = iPEndPoint;
            roomData.m_createTime = ServerMgr.Instance.NowTime;
            roomData.m_roomName = msg.MRoomName;
            roomData.m_password = msg.MPassword;
            m_dicRoomID2Data[roomData.m_roomId] = roomData;

            MsgPB.UserServerRegisterRoomS2RS sendMsg = new MsgPB.UserServerRegisterRoomS2RS();
            sendMsg.MRoomID = roomData.m_roomId;
            ServerMsgReceiver.Instance.sendMsgToRoom(roomData.m_roomId, sendMsg);
        }

        public void onUserServerFindRoomC2S(byte[] protoBytes, uint playerId) {
            MsgPB.UserServerFindRoomC2S msg = MsgPB.UserServerFindRoomC2S.Parser.ParseFrom(protoBytes);
            //ToDo
            MsgPB.UserServerFindRoomS2C sendMsg = new MsgPB.UserServerFindRoomS2C();
            int count = 0;
            foreach(var value in m_dicRoomID2Data.Values) {
                MsgPB.RoomInfo roomInfo = new MsgPB.RoomInfo();
                roomInfo.MRoomID = value.m_roomId;
                roomInfo.MRoomName = value.m_roomName;
                roomInfo.MNeedPassword = (value.m_roomName != string.Empty);
                sendMsg.MLstRoomInfo.Add(roomInfo);
                ++count;
                if(count >= 12) {
                    break;
                }
            }
            ServerMsgReceiver.Instance.sendMsgToPlayer(playerId, sendMsg);
        }
    }
}
