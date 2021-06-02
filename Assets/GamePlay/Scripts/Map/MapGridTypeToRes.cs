using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGridTypeToRes : MonoBehaviour {
    [Serializable]
    public struct MapGridType2ResData {
        public MapGridType m_mapGridType;
        public GameObject m_res;
    }
    [SerializeField]
    private List<MapGridType2ResData> m_listGridType2Res;

    private Dictionary<MapGridType, GameObject> m_dicGridType2Res;

    public static MapGridTypeToRes Instance;

    private void Awake() {
        Instance = this;
        m_dicGridType2Res = new Dictionary<MapGridType, GameObject>();
        foreach(var data in m_listGridType2Res) {
            m_dicGridType2Res.Add(data.m_mapGridType, data.m_res);
        }
    }

    public GameObject getGridTypeGameObj(MapGridType mapGridType) {
        if (m_dicGridType2Res.ContainsKey(mapGridType)) {
            return m_dicGridType2Res[mapGridType];
        }
        return null;
    }
}