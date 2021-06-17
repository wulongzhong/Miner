using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {
    public static GamePlay Instance;

    private ServerMgr m_serverMgr;
    private HandlerMgr m_handlerMgr;

    private void Awake() {
        Instance = this;
        new GameConfig();
        m_handlerMgr = new HandlerMgr();
        m_handlerMgr.initialize();
    }

    private int m_gameRoomSeed;

    public int GameRoomSeed { get => m_gameRoomSeed; set => m_gameRoomSeed = value; }

    private void FixedUpdate() {
        m_handlerMgr.update();
    }

    public void openLocalServer() {
        m_serverMgr = new ServerMgr();
        m_serverMgr.initialize();
        m_serverMgr.startServer(20);
    }

    public void closeLocalServer() {
        m_serverMgr.terminate();
    }

    private void OnDestroy() {
        if(m_serverMgr != null) {
            m_serverMgr.terminate();
        }
        if(m_handlerMgr != null) {
            m_handlerMgr.terminate();
        }
    }
}