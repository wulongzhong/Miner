using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPCStart : UIBevBase {
    public InputField m_inputPlayerId;
    public InputField m_inputIP;
    public InputField m_inputPort;
    public Button m_btnStartLocalPlay;
    public Button m_btnJoinPlay;

    private string m_keyLastIP = "last_ip";
    private string m_keyLastPort = "last_port";
    private string m_keyLastPlayerID = "last_player_id";

    protected override void Start() {
        base.Start();
        m_inputIP.text = PlayerPrefs.GetString(m_keyLastIP, "127.0.0.1");
        m_inputPort.text = PlayerPrefs.GetString(m_keyLastPort, "19981");
        m_inputPlayerId.text = PlayerPrefs.GetString(m_keyLastPlayerID, "1");

        m_btnStartLocalPlay.onClick.AddListener(() => { onBtnStartLocalPlayClick(); });
        m_btnJoinPlay.onClick.AddListener(() => { onBtnJoinPlayClick(); });
    }

    private void onBtnStartLocalPlayClick() {
        onHide();
        GamePlay.Instance.openLocalServer();
        RoomClient.RoomDataCache.Instance.initCache();
        ClientMsgReceiver.Instance.startUdp();
        PlayerMgr.Instance.joinGameRoom();
    }

    private void onBtnJoinPlayClick() {
        onHide();

        GamePlay.Instance.ServerIpAddr = m_inputIP.text;
        GamePlay.Instance.ServerPort = int.Parse(m_inputPort.text);
        PlayerMgr.Instance.SelfPlayerId = uint.Parse(m_inputPlayerId.text);

        PlayerPrefs.SetString(m_keyLastIP, m_inputIP.text);
        PlayerPrefs.SetString(m_keyLastPort, m_inputPort.text);
        PlayerPrefs.SetString(m_keyLastPlayerID, m_inputPlayerId.text);
        ClientMsgReceiver.Instance.startUdp();

        PlayerMgr.Instance.joinGameRoom();
    }

    public override void onHide() {
        base.onHide();
        UIMgr.Instance.showUI("UITestOperate");
    }
}
