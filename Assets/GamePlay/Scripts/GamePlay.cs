using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {
    public static GamePlay Instance;

    private void Awake() {
        Instance = this;
    }

    private int m_gameRoomSeed;
    private string m_serverIpAddr = "127.0.0.1";

    public string ServerIpAddr { get => m_serverIpAddr; set => m_serverIpAddr = value; }
    public int GameRoomSeed { get => m_gameRoomSeed; set => m_gameRoomSeed = value; }
}