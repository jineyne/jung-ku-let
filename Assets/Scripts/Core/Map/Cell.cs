using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    public enum ICellType {
        Movable,
        UnMovable
    }

    public Vector2Int _positionOnGrid;
    public ICellType _cellType;
}
