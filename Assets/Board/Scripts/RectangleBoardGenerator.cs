using System.Collections.Generic;
using UnityEngine;

public class RectangleBoardGenerator : BoardGenerator
{
    private List<Tile> _firstRawTiles = new List<Tile>();

    public override void InitializeBoard()
    {
        tilesSpacing = 0.5f;
        base.InitializeBoard();
        Bounds cameraBounds = GetCameraBounds(currentCamera);

        float minX = cameraBounds.min.x;
        float maxX = cameraBounds.max.x;
        float minZ = cameraBounds.min.z;
        float maxZ = cameraBounds.max.z;

        for (float x = minX + tilesSpacing; x < maxX; x += tilesSpacing)
        {
            for (float z = minZ + tilesSpacing; z < maxZ; z += tilesSpacing)
            {
                Vector3 position = new Vector3(x, 0, z);
                Tile tile = CreateTile(position);
                _tiles.Add(tile);
                if (z == minZ + tilesSpacing)
                {
                    _firstRawTiles.Add(tile);
                }
            }
        }
    }
    public override Tile GetRandomTileInFirstRaw()
    {
        var index = Random.Range(0, _firstRawTiles.Count);
        return _firstRawTiles[index];
    }
}
