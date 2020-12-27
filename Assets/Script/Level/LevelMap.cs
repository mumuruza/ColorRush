using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

public class LevelMap
{
    private TileType[,] _map;

    public Vector2Int size { get; private set; }

    public LevelMap(Vector2Int size)
    {
        this.size = size;
        _map = new TileType[size.x, size.y];
    }

    public LevelMap(TileType[,] map)
    {
        _map = map;
        size = new Vector2Int(map.GetLength(0), map.GetLength(1));
    }

    public TileType this[int x, int y] 
    { 
        get
        {
            if (x < 0 || y < 0 || x >= size.x || y >= size.y)
                throw new Exception("x or y out of bounds");
            return _map[x, y];
        }
    }

    public void SetColor(int x, int y, TileType color, bool ignoreEmpty = true) 
    {
        if (x < 0 || y < 0 || x >= size.x || y >= size.y)
            throw new Exception("x or y out of bounds");
        if (ignoreEmpty && (color == TileType.None || color == TileType.Empty))
            throw new Exception("you can only use colors");
        _map[x, y] = color;
    }

    public TileType[,] MapClone()
    {
        return _map.Clone() as TileType[,];
    }
}
