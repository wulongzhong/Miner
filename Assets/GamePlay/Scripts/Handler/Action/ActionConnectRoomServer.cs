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

        public virtual void end() {

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

    private class PlayerLoginAction : ConnectActionBase {
        public override void start() {
            HandlerRoomPlayer.Instance.joinGameRoom();
        }
        public override State update() {
            return State.SUCCESS;
        }
    }

    private List<ConnectActionBase> m_listAction;

    public override bool initialize() {
        base.initialize();
        m_listAction = new List<ConnectActionBase>();

        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.UserServerJoinRoomS2C), onUserServerJoinRoomS2C);
        return true;
    }

    public void onUserServerJoinRoomS2C(byte[] protoBytes) {
        MsgPB.UserServerJoinRoomS2C msg = MsgPB.UserServerJoinRoomS2C.Parser.ParseFrom(protoBytes);
        m_listAction.Add(new PingRoomServerAction(new IPEndPoint(IPAddress.Parse(msg.MIp), (int)msg.MPort)));
        m_listAction.Add(new PlayerLoginAction());
        m_listAction[0].start();
    }

    public override void update() {
        if(m_listAction.Count > 0) {
            var state = m_listAction[0].update();
            if(state == ConnectActionBase.State.SUCCESS) {
                m_listAction.RemoveAt(0);
                if(m_listAction.Count > 0) {
                    m_listAction[0].start();
                }
            }
            if(state == ConnectActionBase.State.FAIL) {
                m_listAction.Clear();
            }
        }
    }
}