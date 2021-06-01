using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using System;

public enum GridType {
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
    Silver = 3,
    /// <summary>
    /// 金矿
    /// </summary>
    Gold = 4,
    /// <summary>
    /// 钻石矿
    /// </summary>
    Diamond = 5,
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

    public GridType getGridType(Vector2Int pos) {
        byte[,] currPiece = m_mapGridData[pos.x / m_smallPieceGridNum, pos.y / m_smallPieceGridNum];
        if(currPiece == null) {
            return GridType.None;
        }
        return (GridType)currPiece[pos.x % m_smallPieceGridNum, pos.y % m_smallPieceGridNum];
    }

    int sqrRange;
    int minX;
    int maxX;
    int minY;
    int maxY;
    public List<GridType> clearGrid(Vector2Int pos, int range) {
        List<GridType> mines = new List<GridType>();

        sqrRange = range * range;

        minX = pos.x - range;
        if(minX < 0) {
            minX = 0;
        }
        maxX = pos.x + range;
        if(maxX >= m_mapGridWidthNum) {
            maxX = m_mapGridWidthNum - 1;
        }
        minY = pos.y - range;
        if(minY < 0) {
            minY = 0;
        }
        maxY = pos.y + range;
        if(maxY >= m_mapGridHeigthNum) {
            maxY = m_mapGridHeigthNum - 1;
        }

        for(int x = minX; x <= maxX; ++x) {
            for(int y = minY; y < maxY; ++y) {
                int offsetX = x - pos.x;
                int offsetY = y - pos.y;
                int offsetLength = offsetX * offsetX + offsetY * offsetY;
                if(offsetLength <= sqrRange) {

                }
            }
        }

        return mines;
    }

    private void generateGridInfo(Vector2Int posIndex) {
        System.Random rand = new System.Random(m_seed + posIndex.y * m_mapGridWidthNum + posIndex.x);
    }
}
