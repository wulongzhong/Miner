using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : MonoBehaviour {
    public static PlayerMgr Instance;
    public GameObject m_playerPrefab;

    private uint m_selfPlayerId = 1;
    private Dictionary<uint, PlayerBev> m_dicId2PlayerBec;

    public uint SelfPlayerId { get => m_selfPlayerId; set => m_selfPlayerId = value; }

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

    public PlayerBev getSelf() {
        if (m_dicId2PlayerBec.ContainsKey(SelfPlayerId)) {
            return m_dicId2PlayerBec[SelfPlayerId];
        }
        return null;
    }

    public void createPlayer(uint playerId, MsgPB.GameRoomPlayerInfo playerInfo) {
        GameObject playerGameObj = Instantiate(m_playerPrefab, gameObject.transform);
        m_dicId2PlayerBec[playerId] = playerGameObj.GetComponent<PlayerBev>();
    }

    public void joinGameRoom() {
        MsgPB.GameRoomPlayerLogin msg = new MsgPB.GameRoomPlayerLogin();
        msg.MPlayerId = SelfPlayerId;
        ClientMsgReceiver.Instance.sendMsg(msg);
    }
}