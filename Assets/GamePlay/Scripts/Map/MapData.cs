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

    private byte[,][,] m_mapGridData;
    private const int m_mapGridWidthNum = 512 * 4;
    private const int m_mapGridHeigthNum = 1024 * 4;

    private const int m_smallPieceGridNum = 128;

    PerLinNoiseGenerate m_perLinNoiseGenerate;

    private void Awake() {
        Instance = this;
        m_mapGridData = new byte[m_mapGridWidthNum / m_smallPieceGridNum, m_mapGridHeigthNum/ m_smallPieceGridNum][,];
        m_perLinNoiseGenerate = new PerLinNoiseGenerate(GamePlay.Instance.m_seed);
    }

    private void Start() {
    }

    private void testInit() {
        Vector2Int maxPosIndex = new Vector2Int(m_mapGridWidthNum / m_smallPieceGridNum, m_mapGridHeigthNum / m_smallPieceGridNum);
        for(int i = 0; i < maxPosIndex.x; ++i) {
            for(int j = 0; j < maxPosIndex.y; ++j) {
                generateGridInfo(new Vector2Int(i, j));
            }
        }
    }

    public bool isPosIndexInit(Vector2Int posIndex) {
        return false;
    }

    private void generateGridInfo(Vector2Int posIndex) {

        m_mapGridData[posIndex.x, posIndex.y] = new byte[m_smallPieceGridNum, m_smallPieceGridNum];
        byte[,] currPiece = m_mapGridData[posIndex.x, posIndex.y];

        Vector2Int realPos = posIndex * m_smallPieceGridNum;

        for (int i = 0; i < m_smallPieceGridNum; ++i) {
            for (int j = 0; j < m_smallPieceGridNum; ++j) {
                var tempValue = m_perLinNoiseGenerate.OctavePerlin((realPos.x + i) * 1.0f / m_mapGridWidthNum, (realPos.y + j) * 1.0f / m_mapGridHeigthNum);
                //if(tempValue > 0.5f) {
                //    Debug.Log(tempValue);
                //}
                if(tempValue > 0.9f) {
                    currPiece[i, j] = ((byte)MapGridType.GoldMine) << 4;
                } else if(tempValue > 0.8f) {
                    currPiece[i, j] = ((byte)MapGridType.SilverMine) << 4;
                } else if(tempValue > 0.7f) {
                    currPiece[i, j] = ((byte)MapGridType.CopperMine) << 4;
                } else if(tempValue > 0.5f) {
                    currPiece[i, j] = ((byte)MapGridType.IronMine) << 4;
                } else {
                    currPiece[i, j] = 0;
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
        currPiece = m_mapGridData[posIndex.x, posIndex.y];
        return (MapGridType)(currPiece[pos.x % m_smallPieceGridNum, pos.y % m_smallPieceGridNum] >> 4);
    }

    public struct ClearGridInfo {
        public Vector2Int m_pos;
        public MapGridType m_mapGridType;
    }

    private const byte m_byteGridTypeNone = 0b00010000;
    private const byte m_byteGridMineType = 0b11110000;
    private const byte m_byteGridDamge =    0b00001111;
    public void boomGrid(List<Vector2Int> listPos, int damage, ref List<ClearGridInfo> clearGridInfos) {
        foreach(Vector2Int pos in listPos) {
            Vector2Int posIndex = pos / m_smallPieceGridNum;
            byte[,] currPiece = m_mapGridData[posIndex.x, posIndex.y];
            if (currPiece == null) {
                continue;
            }
            Vector2Int smallPos = new Vector2Int(pos.x % m_smallPieceGridNum, pos.y % m_smallPieceGridNum);
            byte gridInfo = currPiece[smallPos.x, smallPos.y];
            if (gridInfo == 0) {
                continue;
            }
            int mineType = gridInfo >> 4;
            int currDamage = (gridInfo & m_byteGridDamge) + damage;
            if(currDamage >= m_byteGridDamge || currDamage > 10) {
                currPiece[smallPos.x, smallPos.y] = 0;
                clearGridInfos.Add(new ClearGridInfo {m_pos = pos, m_mapGridType = (MapGridType)(mineType) });
            } else {
                currPiece[smallPos.x, smallPos.y] = (byte)((mineType << 4) + currDamage);
            }
        }
    }
}
