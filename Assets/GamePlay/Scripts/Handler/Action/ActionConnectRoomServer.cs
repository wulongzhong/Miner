using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class ActionConnectRoomServer : WF.SimpleComponent{
    private class ConnectActionBase {
        public enum State {
            RUNING = 0,
            SUCCESS = 1,
            FAIL = 2
        }

        public virtual void start() {
        }

        public virtual State update() {
            return State.RUNING;
        }

        public virtual void exit() {
        }
    }

    private class PingRoomServerAction : ConnectActionBase {

        private float m_startPingTime;
        private float m_lastPingTime;

        public PingRoomServerAction(IPEndPoint iPEndPoint) {
            ClientMsgReceiver.Instance.setRoomServerIPEndPoint(iPEndPoint);
            ClientMsgReceiver.Instance.sendMsg2RoomServer(new MsgPB.CommonPingA2A());
            m_startPingTime = Time.time;
            m_lastPingTime = Time.time;
        }

        public override void start() {
            base.start();

        }

        public override State update() {

            if (ClientMsgReceiver.Instance.IsConnectRoomServer) {
                return State.SUCCESS;
            }
            if ((Time.time - m_startPingTime) > GameConfig.Instance.PingMaxWaitMS) {
                return State.FAIL;
            }

            if ((Time.time - m_lastPingTime) > GameConfig.Instance.PingIntervalMS) {
                ClientMsgReceiver.Instance.sendMsg2RoomServer(new MsgPB.CommonPingA2A());
                m_lastPingTime = Time.time;
            }
            return State.RUNING;
        }
    }
}