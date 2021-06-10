using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomConfig : MonoBehaviour {
    public static GameRoomConfig Instance;
    private void Awake() {
        Instance = this;
    }

    private int m_chaseFrameCount = 2;
    private int m_frameScale = 2;
    private int m_frameCommandCount = 1;

    public int FrameScale { get => m_frameScale; set => m_frameScale = value; }
    public int FrameCommandCount { get => m_frameCommandCount; set => m_frameCommandCount = value; }
    public int ChaseFrameCount { get => m_chaseFrameCount; set => m_chaseFrameCount = value; }
}