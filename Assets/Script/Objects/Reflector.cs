using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector
{
    public readonly Vector2Int Direction;
    public readonly Vector2Int Position;

    public Reflector(Vector2Int direction, Vector2Int position)
    {
        Direction = direction;
        Position = position;
    }

    public Vector2Int CalculateDirection(Vector2Int oldDirection)
    {
        if (oldDirection.x != 0 && oldDirection.x != Direction.x)
            return new Vector2Int(0, Direction.y);
        if (oldDirection.y != 0 && oldDirection.y != Direction.y)
            return new Vector2Int(Direction.x, 0);
        return oldDirection;
    }
}
