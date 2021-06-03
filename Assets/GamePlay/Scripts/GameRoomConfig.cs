using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoomConfig : MonoBehaviour {
    public static GameRoomConfig Instance;
    private void Awake() {
        Instance = this;
    }
}