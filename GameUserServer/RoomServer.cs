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
        //ToDo
    }

    class RoomServer : WF.SimpleComponent {
        public static RoomServer Instance;
    }
}
