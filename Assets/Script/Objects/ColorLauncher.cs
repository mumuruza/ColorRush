using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorLauncher
{
    public readonly TileType Color;
    public readonly Vector2Int Direction;
    public readonly Vector2Int Position;

    public ColorLauncher(TileType color, Vector2Int direction, Vector2Int position)
    {
        Color = color;
        Direction = direction;
        Position = position;
    }
}
