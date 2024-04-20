using UnityEngine;
using UnityEngine.Tilemaps;
public enum Tetromino
{
    I,
    O,
    T,
    J,
    L,
    S,
    Z,
}

[System.Serializable]
public struct TetrominoData
{
    public Tetromino _tetromino;
    public Tile _tile;
    public Vector2Int[] cells { get; private set; }
    public Vector2Int[,] wallKicks { get; private set; }

    public void Initialize()
    {
        this.cells = Data.Cells[this._tetromino];
        this.wallKicks = Data.WallKicks[this._tetromino];
    }
}
