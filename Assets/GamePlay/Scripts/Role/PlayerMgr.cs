using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour {
    public static PlayerMgr Instance;

    public GameObject m_playerPrefab;

    private Dictionary<uint, PlayerBev> m_dicId2PlayerBec;

    private void Awake() {
        Instance = this;
        m_dicId2PlayerBec = new Dictionary<uint, PlayerBev>();
    }

    public PlayerBev getPlayerBevById(uint playerId) {
        if (m_dicId2PlayerBec.ContainsKey(playerId)) {
            return m_dicId2PlayerBec[playerId];
        }
        return null;
    }

    public void createPlayer(uint playerId, MsgPB.GameRoomPlayerInfo playerInfo) {
        GameObject playerGameObj = Instantiate(m_playerPrefab, gameObject.transform);
        m_dicId2PlayerBec[playerId] = playerGameObj.GetComponent<PlayerBev>();
    }
}
