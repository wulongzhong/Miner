using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPCStart : UIBevBase {
    public InputField m_inputPlayerId;
    public InputField m_inputIP;
    public Button m_btnStartPlay;

    private string m_keyLastIP = "last_ip";
    private string m_keyLastPlayerID = "last_player_id";

    protected override void Start() {
        base.Start();
        m_inputIP.text = PlayerPrefs.GetString(m_keyLastIP, "127.0.0.1");
        m_inputPlayerId.text = PlayerPrefs.GetString(m_keyLastPlayerID, "1");

        m_btnStartPlay.onClick.AddListener(() => { onBtnStartPlayClick(); });
    }

    private void onBtnStartPlayClick() {
        PlayerPrefs.SetString(m_keyLastIP, m_inputIP.text);
        PlayerPrefs.SetString(m_keyLastPlayerID, m_inputPlayerId.text);
    }
}
