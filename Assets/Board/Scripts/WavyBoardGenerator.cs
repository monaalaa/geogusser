using UnityEngine;

public class WavyBoardGenerator : BoardGenerator
{
    private readonly float _waveAmplitude = 1f;
    private readonly float _waveFrequency = 1f;
    private readonly float _waveSpacing = 0.5f;
    public override Tile GetRandomTileInFirstRaw()
    {
        return _tiles[0];
    }

    public override void InitializeBoard()
    {
        base.InitializeBoard();
        tilesSpacing = 0.5f;
        Bounds cameraBounds = GetCameraBounds(Camera.main);

        float zStart = cameraBounds.min.z;
        float zEnd = cameraBounds.max.z;

        float xPosition = Camera.main.transform.position.x;

        for (float z = zStart + _waveSpacing; z < zEnd; z += _waveSpacing)
        {
            float x = _waveAmplitude * Mathf.Sin(_waveFrequency * z);

            Vector3 tilePosition = new Vector3(x, 0, z);

            Tile tile = CreateTile(tilePosition);
            _tiles.Add(tile);
        }
    }
}
