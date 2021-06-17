using System;
using System.Net;
using System.Net.Sockets;
using Google.Protobuf;

namespace GameUserServer {
    class Program {
        static void Main(string[] args) {
            GameConfig gameConfig = new GameConfig();

            ServerMgr serverMgr = new ServerMgr();
            serverMgr.initialize();
            serverMgr.startServer(10);

            Console.WriteLine("input 'stop' stop server");
            while(true) {
                if(Console.ReadLine() == "stop") {
                    break;
                }
            }
            serverMgr.terminate();
        }
    }
}
