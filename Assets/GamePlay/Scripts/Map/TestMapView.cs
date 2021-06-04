using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMapView : MonoBehaviour {
    private void Start() {
        for(int i = 0; i < 128; ++i) {
            for(int j = 0; j < 128; ++j) {
                var prefab = MapGridTypeToRes.Instance.getGridTypeGameObj(MapData.Instance.getGridType(new Vector2Int(i, j)));
                if(prefab != null) {
                    var tempGameObj = Instantiate(prefab, gameObject.transform);
                    tempGameObj.transform.position = new Vector3(i * 0.5f, j * 0.5f, 0);
                }
            }
        }
    }
}
