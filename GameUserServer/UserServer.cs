using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GameUserServer {
    class UserServer {
        public static UserServer Instance;

        public UserServer() {
            Instance = this;
        }

        public IPEndPoint getIpEndPointByUserId(uint userId) {

            return null;
        }

        public uint getUserIdByIPEndPoint(IPEndPoint ipEndPoint) {

            return 0;
        }
    }
}
