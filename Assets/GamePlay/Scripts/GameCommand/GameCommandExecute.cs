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
    }

    private void FixedUpdate() {
        if(m_updateIndex > 0) {
            Physics2D.Simulate(Time.fixedDeltaTime);
        }
    }
}
