using System.Net;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Board _board { get; private set; }
    public TetrominoData _data { get; private set; }
    public Vector3Int[] cells { get; private set; } 
    public Vector3Int _position { get; private set; }
    
    public void Initialize(Board board, Vector3Int position, TetrominoData data)
    {
        this._board = board;
        this._data = data;
        this._position = position;

        if (this.cells == null)
        {
            this.cells = new Vector3Int[_data.cells.Length];
        }

        for (int i = 0; i < cells.Length; i++)
        {
            this.cells[i] = (Vector3Int)_data.cells[i];
        }
        
    }

    private void Update()
    {
        this._board.Clear(this);
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2Int.left);
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2Int.right);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector2Int.down);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HardDrop();
        }
        
        this._board.Set(this);
    }

    private void HardDrop()
    {
        while (Move(Vector2Int.down))
        {
            continue;
        }
        
    }

    private bool Move(Vector2Int translation)
    {
        Vector3Int newPosition = this._position;
        newPosition.x += translation.x;
        newPosition.y += translation.y;

        bool valid = this._board.IsValidPosition(this, newPosition);

        if (valid)
        {
            this._position = newPosition; 
        }

        return valid;
    }
}
