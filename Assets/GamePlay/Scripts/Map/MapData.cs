using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using System;

public enum MapGridType {
    None = 0,
    /// <summary>
    /// 铁矿
    /// </summary>
    IronMine = 1,
    /// <summary>
    /// 铜矿
    /// </summary>
    CopperMine = 2,
    /// <summary>
    /// 银矿
    /// </summary>
    SilverMine = 3,
    /// <summary>
    /// 金矿
    /// </summary>
    GoldMine = 4,
    /// <summary>
    /// 钻石矿
    /// </summary>
    DiamondMine = 5,
}


public class MapData : MonoBehaviour{

    public static MapData Instance;
    public int m_seed;

    private byte[,][,] m_mapGridData;
    private const int m_mapGridWidthNum = 512 * 4;
    private const int m_mapGridHeigthNum = 1024 * 4;

    private const int m_smallPieceGridNum = 128;

    private void Awake() {
        Instance = this;
        m_mapGridData = new byte[m_mapGridWidthNum / m_smallPieceGridNum, m_mapGridHeigthNum/ m_smallPieceGridNum][,];
    }

    public bool isPosIndexInit(Vector2Int posIndex) {
        return false;
    }

    private void generateGridInfo(Vector2Int posIndex) {
        System.Random rand = new System.Random(m_seed + posIndex.y * m_mapGridWidthNum + posIndex.x);
        Vector2Int realPos = posIndex * m_smallPieceGridNum;
        rand.Next(0, 100);

        for (int i = 0; i < realPos.x; ++i) {
            for (int j = 0; j < realPos.y; ++j) {
                var tempValue = Mathf.PerlinNoise(realPos.x * 1.0f / m_mapGridWidthNum, realPos.y * 1.0f / m_mapGridHeigthNum);
                if(tempValue > 0.9f) {

                }
            }
        }
    }

    public MapGridType getGridType(Vector2Int pos) {
        Vector2Int posIndex = pos / m_smallPieceGridNum;
        byte[,] currPiece = m_mapGridData[posIndex.x, posIndex.y];
        if(currPiece == null) {
            if (!isPosIndexInit(posIndex)) {
                generateGridInfo(posIndex);
            }
        }
        return (MapGridType)currPiece[pos.x % m_smallPieceGridNum, pos.y % m_smallPieceGridNum];
    }

    public struct ClearGridInfo {
        public Vector2Int m_pos;
        public MapGridType m_mapGridType;
    }

    public void boomGrid(List<Vector2Int> pos, int damage, ref List<ClearGridInfo> clearGridInfos) {

    }
}
