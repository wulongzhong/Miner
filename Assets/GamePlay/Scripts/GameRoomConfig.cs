using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomConfig : MonoBehaviour {
    public static GameRoomConfig Instance;
    private void Awake() {
        Instance = this;
    }

    private int m_frameScale = 3;

    public int FrameScale { get => m_frameScale; set => m_frameScale = value; }
}