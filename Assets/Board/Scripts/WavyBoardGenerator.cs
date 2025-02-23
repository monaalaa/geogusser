using UnityEngine;

public class WavyBoardGenerator : BoardGenerator
{
   private float waveAmplitude = 1f;
    private float waveFrequency = 1f;
    private float waveSpacing = 0.5f;
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

        for (float z = zStart + waveSpacing; z < zEnd; z += waveSpacing)
        {
            float x = waveAmplitude * Mathf.Sin(waveFrequency * z);

            Vector3 tilePosition = new Vector3(x, 0, z);

            Tile tile = CreateTile(tilePosition);
            _tiles.Add(tile);
        }
    }
}
