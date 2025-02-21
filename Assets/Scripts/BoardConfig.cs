using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardConfig", menuName = "Board/BoardConfig")]
public class BoardConfig : ScriptableObject
{
    public List<TileData> Tiles;
}

[System.Serializable]
public class TileData
{
    public TileType Type; // Enum to differentiate between tile types
    public Vector2 Position; // Position of the tile on the board
    public int MinigameIndex; // Index for minigame tiles (if applicable)
}

public enum TileType
{
    Empty,
    Minigame
}
