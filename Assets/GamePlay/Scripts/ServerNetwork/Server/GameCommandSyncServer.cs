using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommandSyncServer : MonoBehaviour {
    public static GameCommandSyncServer Instance;
    uint m_frameIndex = 0;
    MsgPB.GameCommandS2C m_currCommandS2C;
    List<MsgPB.GameCommandS2C> m_listCacheGameRoomandS2C;

    private void Awake() {
        Instance = this;
        m_currCommandS2C = new MsgPB.GameCommandS2C();
        m_listCacheGameRoomandS2C = new List<MsgPB.GameCommandS2C>();
    }

    private void Start() {
        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.GameCommandInfo), onGameCommandC2S);
        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.GameCommandRetrieveC2S), onGameCommandRetrieveC2S);
    }

    public void onGameCommandC2S(byte[] protobytes, uint playerId) {
        MsgPB.GameCommandInfo msg = MsgPB.GameCommandInfo.Parser.ParseFrom(protobytes);
        msg.MPlayerId = playerId;
        m_currCommandS2C.MLstGameCommandInfo.Add(msg);
    }

    public void onGameCommandRetrieveC2S(byte[] protobytes, uint playerId) {
        MsgPB.GameCommandRetrieveC2S msg = MsgPB.GameCommandRetrieveC2S.Parser.ParseFrom(protobytes);
        if(m_listCacheGameRoomandS2C.Count == 0) {
            ServerLog.log("m_listCacheGameRoomandS2C.Count == 0");
            return;
        }
        if(m_listCacheGameRoomandS2C[0].MFrameIndex <= msg.MFrameIndex) {
            int offset = (int)(msg.MFrameIndex - m_listCacheGameRoomandS2C[0].MFrameIndex);
            if(offset < m_listCacheGameRoomandS2C.Count) {
                ServerMsgReceiver.Instance.sendMsg(playerId, m_listCacheGameRoomandS2C[offset]);
            } else {
                ServerLog.log("offset >= m_listCacheGameRoomandS2C.Count");
            }
        } else {
            ServerLog.log("m_listCacheGameRoomandS2C[0].MFrameIndex > msg.MFrameIndex");
        }
    }

    public void addPlayer(uint playerId) {
        MsgPB.GameCommandInfo msg = new MsgPB.GameCommandInfo();
        msg.MPlayerId = playerId;
        msg.MCreatePlayer = new MsgPB.GameCommand_CreatePlayer();
        msg.MCreatePlayer.MPlayerInfo = new MsgPB.GameRoomPlayerInfo();
        msg.MCreatePlayer.MPlayerInfo.MPlayerId = playerId;
        m_currCommandS2C.MLstGameCommandInfo.Add(msg);
    }
    private int m_sendRemaining = 0;
    private void FixedUpdate() {
        m_sendRemaining--;
        if (m_sendRemaining > 0) {
            return;
        }
        m_sendRemaining = GameRoomConfig.Instance.FrameScale;
        ++m_frameIndex;
        m_currCommandS2C.MFrameIndex = m_frameIndex;
        ServerMsgReceiver.Instance.sendMsg(PlayerServer.Instance.getAllPlayerId(), m_currCommandS2C);
        m_listCacheGameRoomandS2C.Add(m_currCommandS2C);
        if(m_listCacheGameRoomandS2C.Count > 200) {
            m_listCacheGameRoomandS2C.RemoveAt(0);
        }
        m_currCommandS2C = new MsgPB.GameCommandS2C();
    }
}