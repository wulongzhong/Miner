using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPCStart : UIBevBase {
    public Button m_btnStartLocalPlay;
    public Button m_btnJoinPlay;

    protected override void Start() {
        base.Start();

        m_btnStartLocalPlay.onClick.AddListener(() => { onBtnStartLocalPlayClick(); });
        m_btnJoinPlay.onClick.AddListener(() => { onBtnJoinPlayClick(); });
    }

    private void onBtnStartLocalPlayClick() {
        doHide();
        GamePlay.Instance.openLocalServer();
        HandlerRoomDataCache.Instance.initCache();
    }

    private void onBtnJoinPlayClick() {
        doHide();
    }

    public override void doHide() {
        base.doHide();
        UIMgr.Instance.showUI("UITestOperate");
    }
}
