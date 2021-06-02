using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {
    public static GamePlay Instance;

    private void Awake() {
        Instance = this;
    }

    public int m_seed;
}
