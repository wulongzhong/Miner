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
    }

    public GameObject getGridTypeGameObj(MapGridType mapGridType) {
        if (m_dicGridType2Res.ContainsKey(mapGridType)) {
            return m_dicGridType2Res[mapGridType];
        }
        return null;
    }
}