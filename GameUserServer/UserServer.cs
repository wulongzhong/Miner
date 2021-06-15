using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameUserServer {
    class UserServer : WF.SimpleComponent {
        public static UserServer Instance;

        public override bool initialize() {
            base.initialize();
            Instance = this;
            return true;
        }

        public IPEndPoint getIpEndPointByUserId(uint userId) {

            return null;
        }

        public uint getUserIdByIPEndPoint(IPEndPoint ipEndPoint) {

            return 0;
        }
    }
}
