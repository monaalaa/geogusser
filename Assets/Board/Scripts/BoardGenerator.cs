using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
public abstract class BoardGenerator
{
    public abstract Tile GetRandomTileInFirstRaw();
    protected float tilesSpacing;
    protected List<Tile> _tiles;
    protected  IObjectResolver _objectResolver;
    protected Camera _currentCamera;
    private MinigameTile _quizTile;
    private EmptyTile _emptyTile;

    public void InitBoardData(EmptyTile emptyTile, MinigameTile quizTile, IObjectResolver objectResolver)
    {
        _emptyTile = emptyTile;
        _quizTile = quizTile;
        _objectResolver = objectResolver;
    }
    public virtual void InitializeBoard()
    {
        _tiles = new List<Tile>();
        _currentCamera= Camera.main;
    }
    protected Tile CreateTile(Vector3 position)
    {
        int randomChoice = Random.Range(0, 5);

        Tile tile = randomChoice == 0
            ? _objectResolver.Instantiate(_quizTile, position, Quaternion.identity)
            : _objectResolver.Instantiate(_emptyTile, position, Quaternion.identity);

        tile.Initialize(position);
        return tile;
    }
    protected Bounds GetCameraBounds(Camera camera)
    {
        Vector3 cameraPos = camera.transform.position;

        float height = camera.orthographicSize * 2;
        float width = height * camera.aspect;

        float minX = cameraPos.x - width / 2;
        float maxX = cameraPos.x + width / 2;
        float minZ = cameraPos.z - height / 2;
        float maxZ = cameraPos.z + height / 2;

        return new Bounds(cameraPos, new Vector3(maxX - minX, height, maxZ - minZ));
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
}
