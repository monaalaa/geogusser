using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
public class BoardManager
{
    private float maxXPos = 5f;
    private float maxZPos = 9f;
    private float spacingBetweenTiles = 0.5f;

    private List<Tile> _tiles;
    private List<Tile> _firstRawTiles = new List<Tile>();
    private MinigameTile _quizTile;
    private EmptyTile _emptyTile;

    private IObjectResolver _objectResolver;

    public BoardManager(EmptyTile emptyTile, MinigameTile quizTile, IObjectResolver objectResolver)
    {
        _emptyTile = emptyTile;
        _quizTile = quizTile;
        _objectResolver = objectResolver;
    }

    public void InitializeBoard()
    {
        _tiles = new List<Tile>();
        for (float x = 0; x <= maxXPos; x += spacingBetweenTiles)
        {
            for (float z = 0; z <= maxZPos; z += spacingBetweenTiles)
            {
                
                Vector3 position = new Vector3(x, 0, z);
                Tile tile = CreateTile(position);
                _tiles.Add(tile);
                if (z == 0)
                {
                    _firstRawTiles.Add(tile);
                }
            }
        }
    }

    private Tile CreateTile(Vector3 position)
    {
        int randomChoice = Random.Range(0, 5);

        Tile tile = randomChoice == 0
            ? _objectResolver.Instantiate(_quizTile, position, Quaternion.identity)
            : _objectResolver.Instantiate(_emptyTile, position, Quaternion.identity);

        tile.Initialize(position);
        return tile;
    }

    public Tile GetNextTile(Tile currentTile)
    {
        int currentIndex = _tiles.IndexOf(currentTile);

        if (currentIndex >= 0)
        {
            int nextIndex = (currentIndex + 1) % _tiles.Count;

            return _tiles[nextIndex];
        }

        Debug.LogError("Current tile not found in the tiles list!");
        return null;
    }

    public Tile GetRandomTileInFirstRaw()
    {
        var index = Random.Range(0, _firstRawTiles.Count);
        return _firstRawTiles[index];
    }
}
