using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile2D : Tile
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public override void SetType(TileType type)
    {
        base.SetType(type);
        spriteRenderer.color = type.ToColor();
    }
}
