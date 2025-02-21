using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
     private float minXPos = 0.15f;
     private float maxXPos = 4.3f;
     private float minZPos = -30f;
     private float maxZPos = -18.5f;
     private float spacingBetweenTiles = 0.5f;
  
    private List<Tile> _tiles;
    private MinigameTile _quizTile;
    private EmptyTile _emptyTile;

    public BoardManager( EmptyTile emptyTile, MinigameTile quizTile)
    {
        _emptyTile = emptyTile;
        _quizTile = quizTile;
    }

    public void InitializeBoard()
    {
        _tiles = new List<Tile>();

        for (float x = minXPos; x <= maxXPos; x += spacingBetweenTiles)
        {
            for (float z = minZPos; z <= maxZPos; z += spacingBetweenTiles)
            {
                Vector3 position = new Vector3(x, 0, z);
                Tile tile = CreateTile(position);
                _tiles.Add(tile);
            }
        }
    }
 
    private Tile CreateTile(Vector3 position)
    {

        int randomChoice = Random.Range(0, 5);

        Tile tile = randomChoice == 0
            ? Instantiate(_quizTile, position, Quaternion.identity)
            : Instantiate(_emptyTile, position, Quaternion.identity);

        tile.Initialize(position);
        return tile;
    }

    public Vector3 GetTilePosition(int steps)
    {
        if (steps >= _tiles.Count)
            return _tiles[0].Position;  

        return _tiles[steps].Position;
    }

    public void OnPlayerLandsOnTile(Vector3 targetPosition)
    {
        // Check which tile the player landed on and trigger the respective event
        Tile landedTile = _tiles.Find(tile => tile.Position == targetPosition);
        landedTile.OnLand();
    }

}
