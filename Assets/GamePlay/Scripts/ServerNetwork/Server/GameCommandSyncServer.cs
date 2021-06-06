using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommandSyncServer : MonoBehaviour {
    public static GameCommandSyncServer Instance;

    MsgPB.GameCommandS2C m_gameCommandS2C;

    private void Awake() {
        Instance = this;
        m_gameCommandS2C = new MsgPB.GameCommandS2C();
    }

    private void Start() {
        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.GameCommandInfo), onGameCommandC2S);
    }

    public void onGameCommandC2S(byte[] protobytes, uint playerId) {
        MsgPB.GameCommandInfo msg = MsgPB.GameCommandInfo.Parser.ParseFrom(protobytes);
        msg.MPlayerId = playerId;
        m_gameCommandS2C.MLstGameCommandInfo.Add(msg);
    }

    public void addPlayer(uint playerId) {
        MsgPB.GameCommandInfo msg = new MsgPB.GameCommandInfo();
        msg.MPlayerId = playerId;
        msg.MCreatePlayer = new MsgPB.GameCommand_CreatePlayer();
        msg.MCreatePlayer.MPlayerInfo = new MsgPB.GameRoomPlayerInfo();
        msg.MCreatePlayer.MPlayerInfo.MPlayerId = playerId;
        m_gameCommandS2C.MLstGameCommandInfo.Add(msg);
    }

    private void FixedUpdate() {
        ServerMsgReceiver.Instance.sendMsg(PlayerServer.Instance.getAllPlayerId(), m_gameCommandS2C);
        m_gameCommandS2C = new MsgPB.GameCommandS2C();
    }
}