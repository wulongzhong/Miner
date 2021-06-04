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

        Physics2D.Simulate(Time.fixedDeltaTime);
    }

    public void onGameCommandS2C(byte[] protobytes) {
        MsgPB.GameCommandS2C msg = MsgPB.GameCommandS2C.Parser.ParseFrom(protobytes);

    }
}
