using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableTile : Tile2D, IPointerClickHandler
{
    private int _x;
    private int _y;

    public event Action<int, int> TileClicked;

    public void Init(int x, int y) 
    {
        _x = x;
        _y = y;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TileClicked?.Invoke(_x, _y);
    }
}
