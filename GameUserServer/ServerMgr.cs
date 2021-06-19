using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameUserServer {
    public class ServerMgr : WF.SimpleComponent {
        public static ServerMgr Instance;

        private bool m_bStart = false;
        private bool m_bPause = false;
        private Thread m_updateThread;
        private int m_frameMilliseconds;
        private long m_lastUpdateTime;
        private long m_nowTime;
        private int m_lastOffsetTime;

        //log
        private long m_startTime;
        private int m_updateCount;
        Dictionary<int/*time offset*/, int/*count*/> m_dicLog;

        public long LastUpdateTime { get => m_lastUpdateTime; }
        public long NowTime { get => m_nowTime; }

        public override bool initialize() {
            base.initialize();
            Instance = this;

            m_dicLog = new Dictionary<int, int>();

            ServerMsgReceiver serverMsgReceiver = new ServerMsgReceiver();
            serverMsgReceiver.initialize();
            addComponent(serverMsgReceiver);

            PlayerServer playerServer = new PlayerServer();
            playerServer.initialize();
            addComponent(playerServer);

            RoomServer roomServer = new RoomServer();
            roomServer.initialize();
            addComponent(roomServer);

            return true;
        }

        public override void terminate() {
            base.terminate();
            stopServer();
            ServerLog.log(string.Format("average update Time : {0}", (m_lastUpdateTime - m_startTime) / m_updateCount));
            foreach (var keyValue in m_dicLog) {
                ServerLog.log(string.Format("offsetTime:{0}, count:{1}", keyValue.Key, keyValue.Value));
            }
        }


        public void startServer(int frameMilliseconds) {
            m_bStart = true;
            m_frameMilliseconds = frameMilliseconds;
            m_updateThread = new Thread(serverUpdate);
            m_updateThread.Start();
        }

        public void pauseServer() {
            m_bPause = true;
        }

        public void continueServer() {
            m_bPause = false;
        }

        public void stopServer() {
            m_bStart = false;
        }


        private void serverUpdate() {
            m_startTime = (long)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
            m_lastUpdateTime = m_startTime;

            while (m_bStart) {
                if (m_bPause) {
                    Thread.Sleep(1);
                    continue;
                }
                m_nowTime = (long)(System.DateTime.UtcNow - new System.DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
                int offsetTime = (int)((m_lastUpdateTime + m_frameMilliseconds + m_lastOffsetTime) - m_nowTime);
                if (offsetTime <= 0) {
                    m_lastOffsetTime = offsetTime;
                    update();
                    m_updateCount++;
                    if (m_dicLog.ContainsKey(offsetTime)) {
                        m_dicLog[offsetTime] += 1;
                    } else {
                        m_dicLog[offsetTime] = 1;
                    }
                    m_lastUpdateTime = m_nowTime;
                } else {
                    Thread.Sleep(1);
                }
            }
        }
    }
}
