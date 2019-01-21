using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {
    public Vector2Int _size = Vector2Int.zero;
    public GameObject[] BlockingCellObject;
    public GameObject[] RoadCellObject;

    private Cell[] mCells;
    private GameObject RoadCellPicker {
        get {
            return RoadCellObject[Random.Range(0, RoadCellObject.Length)];
        }
    }

    private GameObject BlockingCellPicker {
        get {
            return BlockingCellObject[Random.Range(0, BlockingCellObject.Length)];
        }
    }

    public void Awake() {
        mCells = new Cell[_size.sqrMagnitude];
        for (int x = 0; x < _size.x; x++) {
            for (int y = 0; y < _size.y; y++) {
                GameObject go = Instantiate(BlockingCellPicker, new Vector3(x, y), Quaternion.identity);
                go.transform.parent = this.gameObject.transform;
                Cell cell = null;
                if((cell = go.GetComponent<Cell>()) == null) {
                    cell = go.AddComponent<Cell>();
                }
                cell._positionOnGrid = new Vector2Int(x, y);
                mCells[x * _size.x + y] = cell;
            }
        }
    }

    public bool[] GetBoolArray() {
        bool[] res = new bool[_size.sqrMagnitude];

        for (int x = 0; x < _size.x; x++) {
            for (int y = 0; y < _size.y; y++) {
                res[x * _size.x + y] = GetAt(x, y)._cellType == Cell.ICellType.Movable;
            }
        }

        return res;
    }

    public Cell GetAt(int x, int y) {
        return mCells[x * _size.x + y];
    }

    public Cell GetAt(Vector2Int vec) {
        return GetAt(vec.x, vec.y);
    }

    public void SetAt(int x, int y, Cell cell) {
        mCells[x * _size.x + y] = cell;
    }

    public void SetAt(Vector2Int vec, Cell cell) {
        SetAt(vec.x, vec.y, cell);
    }
}
