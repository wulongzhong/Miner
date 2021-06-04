using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommandExecute : MonoBehaviour {
    private List<MsgPB.GameCommandS2C> m_listGameCommand;

    private int m_updateIndex;
    private void Awake() {
        Physics2D.simulationMode = SimulationMode2D.Script;
    }
    private void Start() {
        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.GameCommandS2C), onGameCommandS2C);
    }

    private void FixedUpdate() {
        executeCommand();
    }

    private void executeCommand() {
        if(m_listGameCommand.Count == 0) {
            return;
        }
        MsgPB.GameCommandS2C currCommandS2C = m_listGameCommand[0];
        m_listGameCommand.RemoveAt(0);

        //excute
        foreach(MsgPB.GameCommandInfo commandInfo in currCommandS2C.MLstGameCommandInfo) {
            PlayerBev playerBev = PlayerMgr.Instance.getPlayerBevById(commandInfo.MPlayerId);
            if(playerBev == null) {
                Debug.LogError("playerBev == null");
                continue;
            }
            if(commandInfo.MPlayerMove != null) {

            }
        }

        Physics2D.Simulate(Time.fixedDeltaTime);
    }

    public void onGameCommandS2C(byte[] protobytes) {
        MsgPB.GameCommandS2C msg = MsgPB.GameCommandS2C.Parser.ParseFrom(protobytes);
        m_listGameCommand.Add(msg);
    }
}
