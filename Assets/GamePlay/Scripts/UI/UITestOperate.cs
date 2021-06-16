using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITestOperate : UIBevBase {
    public Button m_btnJump;

    protected override void Start() {
        base.Start();
        m_btnJump.onClick.AddListener(() => { onBtnJumpClick(); });
    }

    private void onBtnJumpClick() {
        HandlerRoomCommandFactory.Instance.makePlayerJump();
    }
}
