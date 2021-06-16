using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjFactory : MonoBehaviour {
    public static GameObjFactory Instance;

    public GameObject m_playerPrefab;

    private void Awake() {
        Instance = this;
    }

    public PlayerBev createPlayer() {
        GameObject playerObj = Instantiate(m_playerPrefab, gameObject.transform);
        return playerObj.GetComponent<PlayerBev>();
    }
}
