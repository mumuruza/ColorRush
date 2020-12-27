using System;
using System.Collections.Generic;
using UnityEngine;

public enum TileType 
{
    None = 0,
    Empty, 
    Red, 
    Green
}

public static class TileTypeExtentions
{
    private static List <TileType> _tileTypes;

    public static TileType Next(this TileType tileType, bool onlyColors = false)
    {
        if (_tileTypes == null)
            InitList();
        int index = (_tileTypes.IndexOf(tileType) + 1) % _tileTypes.Count;
        if (onlyColors && (_tileTypes[index] == TileType.None || _tileTypes[index] == TileType.Empty))
            return _tileTypes[index].Next(true);

        return _tileTypes[index];
    }

    public static Color ToColor(this TileType a) 
    {
        switch (a)
        {
            case TileType.None:
                return new Color(0, 0, 0, 0);
            case TileType.Empty:
                return Color.gray;
            case TileType.Red:
                return Color.red;
            case TileType.Green:
                return Color.green;
            default:
                return new Color(0, 0, 0, 0);
        }
    }

    private static void InitList() 
    {
        _tileTypes = new List<TileType>();
        for (int i = 0; i < Enum.GetValues(typeof(TileType)).Length; i++)
        {
            _tileTypes.Add((TileType)i);
        }
    }
}
