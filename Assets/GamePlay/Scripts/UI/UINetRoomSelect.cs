using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINetRoomSelect : UIBevBase {

    public GameObject m_panInfo;
    public Button m_btnClose;
    public Button m_btnJoin;

    private uint m_roomId = 0;

    protected override void Start() {
        base.Start();

        m_btnClose.onClick.AddListener(() => { onBtnCloseClick(); });
        m_btnJoin.onClick.AddListener(() => { onBtnJoinClick(); });

        m_panInfo.SetActive(false);
        Transform panInfoParent = m_panInfo.transform.parent;
        for (int i = 1; i < panInfoParent.childCount; ++i) {
            Destroy(panInfoParent.GetChild(i).gameObject);
        }

        ClientMsgReceiver.Instance.registerS2C(typeof(MsgPB.UserServerFindRoomS2C), onUserServerFindRoomS2C);
    }

    public override void doShow() {
        base.doShow();
        m_btnJoin.interactable = false;
        ClientMsgReceiver.Instance.sendMsg2UserServer(new MsgPB.UserServerFindRoomC2S());
    }

    public void onUserServerFindRoomS2C(byte[] protobytes) {
        if (!gameObject.activeInHierarchy) {
            return;
        }
        MsgPB.UserServerFindRoomS2C msg = MsgPB.UserServerFindRoomS2C.Parser.ParseFrom(protobytes);
        foreach(var roomInfo in msg.MLstRoomInfo) {
            GameObject tempPanInfo = Instantiate(m_panInfo, m_panInfo.transform.parent);
            tempPanInfo.SetActive(true);
            uint roomId = roomInfo.MRoomID;
            tempPanInfo.transform.GetChild(0).gameObject.GetComponent<Text>().text = string.Format("room id:{0} room name:{1}", roomId, roomInfo.MRoomName);
            tempPanInfo.transform.GetChild(1).gameObject.GetComponent<Button>().onClick.AddListener(() => { onRoomBtnClick(roomId); });
        }
    }

    public void onRoomBtnClick(uint roomId) {
        m_roomId = roomId;
        m_btnJoin.interactable = true;
    }

    public void onBtnCloseClick() {
        doHide();
    }

    public void onBtnJoinClick() {
        MsgPB.UserServerJoinRoomC2S msg = new MsgPB.UserServerJoinRoomC2S();
        msg.MRoomID = m_roomId;
        ClientMsgReceiver.Instance.sendMsg2UserServer(msg);
        doHide();
    }
}
