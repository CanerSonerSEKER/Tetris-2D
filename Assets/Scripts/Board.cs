using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;
public class Board : MonoBehaviour
{
    public Tilemap _tilemap { get; private set; }
    public Piece activePiece { get; private set; }
    public TetrominoData[] _tetrominoes;
    public Vector3Int spawnPosition;

    private void Awake()
    {
        this._tilemap = GetComponentInChildren<Tilemap>();
        this.activePiece = GetComponentInChildren<Piece>();
        
        for (int i = 0; i < this._tetrominoes.Length; i++)
        {
            this._tetrominoes[i].Initialize();
        }
    }

    private void Start()
    {
        SpawnPiece();
    }

    public void SpawnPiece()
    {
        int random = Random.Range(0, this._tetrominoes.Length);
        TetrominoData data = this._tetrominoes[random];
        
        this.activePiece.Initialize(this, this.spawnPosition, data);
        Set(this.activePiece);
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i] + piece.position;
            this._tilemap.SetTile(tilePosition, piece.data._tile);
        }
    }
}
