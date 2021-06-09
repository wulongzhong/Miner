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
    public int FrameCommandCount { get => m_frameCommandCount; set => m_frameCommandCount = value; }
    private int m_frameCommandCount = 1;
}