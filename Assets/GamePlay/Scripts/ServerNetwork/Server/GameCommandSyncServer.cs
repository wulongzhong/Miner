using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommandSyncServer : WF.SimpleComponent {
    public static GameCommandSyncServer Instance;
    uint m_frameIndex = 0;
    Dictionary<uint/*playerId*/, MsgPB.GameCommandInfo> m_dicPlayerCommandInfo;
    List<MsgPB.GameFrameAllCommandInfo> m_listCacheGameRoomandS2C;

    public override bool initialize() {
        base.initialize();
        Instance = this;
        m_listCacheGameRoomandS2C = new List<MsgPB.GameFrameAllCommandInfo>();
        m_dicPlayerCommandInfo = new Dictionary<uint, MsgPB.GameCommandInfo>();

        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.GameCommandInfo), onGameCommandC2S);
        ServerMsgReceiver.Instance.registerC2S(typeof(MsgPB.GameCommandRetrieveC2S), onGameCommandRetrieveC2S);
        return true;
    }

    public void onGameCommandC2S(byte[] protobytes, uint playerId) {
        MsgPB.GameCommandInfo msg = MsgPB.GameCommandInfo.Parser.ParseFrom(protobytes);
        msg.MPlayerId = playerId;
        if (m_dicPlayerCommandInfo.ContainsKey(playerId)) {
            MsgPB.GameCommandInfo lastMsg = m_dicPlayerCommandInfo[playerId];
            if(msg.MPlayerMove != null) {
                lastMsg.MPlayerMove = msg.MPlayerMove;
            }
            if(msg.MPlayerJump != null) {
                lastMsg.MPlayerJump = msg.MPlayerJump;
            }
        } else {
            m_dicPlayerCommandInfo[playerId] = msg;
        }
    }

    public void onGameCommandRetrieveC2S(byte[] protobytes, uint playerId) {
        MsgPB.GameCommandRetrieveC2S msg = MsgPB.GameCommandRetrieveC2S.Parser.ParseFrom(protobytes);
        if(m_listCacheGameRoomandS2C.Count == 0) {
            ServerLog.log("m_listCacheGameRoomandS2C.Count == 0");
            return;
        }
        foreach(uint retrieveFrameIndex in msg.MFrameIndex) {
            if (m_listCacheGameRoomandS2C[0].MFrameIndex <= retrieveFrameIndex) {
                int offset = (int)(retrieveFrameIndex - m_listCacheGameRoomandS2C[0].MFrameIndex);
                if(offset < 0) {
                    MsgPB.GameCommandRetrieveErrorS2C errorMsg = new MsgPB.GameCommandRetrieveErrorS2C();
                    ServerMsgReceiver.Instance.sendMsg(playerId, errorMsg);
                    return;
                }
                if (offset < m_listCacheGameRoomandS2C.Count) {
                    ServerMsgReceiver.Instance.sendMsg(playerId, m_listCacheGameRoomandS2C[offset]);
                } else {
                    ServerLog.log("offset >= m_listCacheGameRoomandS2C.Count");
                }
            } else {
                ServerLog.log("m_listCacheGameRoomandS2C[0].MFrameIndex > msg.MFrameIndex");
            }
        }
    }

    public void addPlayer(uint playerId) {
        MsgPB.GameCommandInfo msg = new MsgPB.GameCommandInfo();
        msg.MPlayerId = playerId;
        msg.MCreatePlayer = new MsgPB.GameCommand_CreatePlayer();
        msg.MCreatePlayer.MPlayerInfo = new MsgPB.GameRoomPlayerInfo();
        msg.MCreatePlayer.MPlayerInfo.MPlayerId = playerId;
        m_dicPlayerCommandInfo[playerId] = msg;
        Debug.LogFormat("GameCommandSyncServer add player id:{0}, frameIndex:{1}", playerId, m_frameIndex + 1);
    }

    public void syncCacheCommandToNewPlayer(uint playerId, uint roomCahceIndex) {
        if(m_listCacheGameRoomandS2C.Count == 0) {
            return;
        }
        int offset = (int)(roomCahceIndex - m_listCacheGameRoomandS2C[0].MFrameIndex) + 1;
        for(;offset < m_listCacheGameRoomandS2C.Count; ++offset) {
            ServerMsgReceiver.Instance.sendMsg(playerId, m_listCacheGameRoomandS2C[offset]);
        }
    }

    private int m_sendRemaining = 0;
    public override void update() {
        m_sendRemaining--;
        if (m_sendRemaining > 0) {
            return;
        }
        m_sendRemaining = GameRoomConfig.Instance.FrameScale;
        ++m_frameIndex;
        MsgPB.GameFrameAllCommandInfo currCommandS2C = new MsgPB.GameFrameAllCommandInfo();
        currCommandS2C.MFrameIndex = m_frameIndex;
        currCommandS2C.MLstGameCommandInfo.Add(m_dicPlayerCommandInfo.Values);
        m_dicPlayerCommandInfo.Clear();

        m_listCacheGameRoomandS2C.Add(currCommandS2C);
        if (m_listCacheGameRoomandS2C.Count > GameRoomConfig.Instance.CacheFrameCommandCount) {
            m_listCacheGameRoomandS2C.RemoveAt(0);
        }

        if(GameRoomConfig.Instance.FrameCommandCount == 1) {
            ServerMsgReceiver.Instance.sendMsg(PlayerServer.Instance.getAllPlayerId(), m_listCacheGameRoomandS2C[m_listCacheGameRoomandS2C.Count - 1]);
        } else {
            MsgPB.GameCommandS2C msg = new MsgPB.GameCommandS2C();
            for (int i = m_listCacheGameRoomandS2C.Count - 1; (i >= 0) && (i >= (m_listCacheGameRoomandS2C.Count - GameRoomConfig.Instance.FrameCommandCount)); --i) {
                msg.MLstFrameAllCommandInfo.Add(m_listCacheGameRoomandS2C[i]);
            }
            ServerMsgReceiver.Instance.sendMsg(PlayerServer.Instance.getAllPlayerId(), msg);
        }
    }
}