using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{
    public TileType TileType { get; protected set; }
    public virtual void SetType(TileType type)
    {
        TileType = type;
    }

}
