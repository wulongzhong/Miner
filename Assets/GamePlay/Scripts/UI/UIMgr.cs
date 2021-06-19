using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    public static UIMgr Instance;

    private Dictionary<string, GameObject> m_UIPath2GameObj;


    private void Awake() {
        Instance = this;
        m_UIPath2GameObj = new Dictionary<string, GameObject>();
        for (int i = 0; i < gameObject.transform.childCount; ++i) {
            var uiGameObj = gameObject.transform.GetChild(i).gameObject;
            m_UIPath2GameObj.Add(uiGameObj.name.ToLower(), uiGameObj);
        }
    }


    public UIBevBase showUI(string strUIPath) {
        strUIPath = strUIPath.ToLower();
        if (m_UIPath2GameObj.ContainsKey(strUIPath)) {
            var uiGameObj = m_UIPath2GameObj[strUIPath];
            var uiBev = uiGameObj.GetComponent<UIBevBase>();
            uiBev.doShow();
            return uiBev;
        }
        return null;
    }

    public UIBevBase findUI(string strUIPath) {
        strUIPath = strUIPath.ToLower();
        if (m_UIPath2GameObj.ContainsKey(strUIPath)) {
            return m_UIPath2GameObj[strUIPath].GetComponent<UIBevBase>();
        }
        return null;
    }

    public void hideUI(string strUIPath) {
        strUIPath = strUIPath.ToLower();
        if (m_UIPath2GameObj.ContainsKey(strUIPath)) {
            var uiGameObj = m_UIPath2GameObj[strUIPath];
            var uiBev = uiGameObj.GetComponent<UIBevBase>();
            uiBev.doHide();
        }
    }
}
