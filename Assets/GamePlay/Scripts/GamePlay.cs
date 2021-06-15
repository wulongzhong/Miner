using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {
    public static GamePlay Instance;

    private ServerMgr m_serverMgr;

    private void Awake() {
        Instance = this;
    }

    private int m_gameRoomSeed;
    private string m_serverIpAddr = "127.0.0.1";
    private int m_serverPort = 19981;

    public string ServerIpAddr { get => m_serverIpAddr; set => m_serverIpAddr = value; }
    public int GameRoomSeed { get => m_gameRoomSeed; set => m_gameRoomSeed = value; }
    public int ServerPort { get => m_serverPort; set => m_serverPort = value; }

    private void Update() {

    }

    public void openLocalServer() {
        m_serverMgr = new ServerMgr();
        m_serverMgr.initialize();
        m_serverMgr.startServer(16);
    }

    public void closeLocalServer() {
        m_serverMgr.terminate();
    }

    private void OnDestroy() {
        if(m_serverMgr != null) {
            m_serverMgr.terminate();
        }
    }
}