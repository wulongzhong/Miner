using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerServer : MonoBehaviour {

    public static PlayerServer Instance;

    private void Awake() {
        Instance = this;
        m_listPlayerIds = new List<uint>();
    }

    List<uint> m_listPlayerIds;

    public List<uint> getAllPlayerId() {
        return new List<uint>(m_listPlayerIds);
    }
}
