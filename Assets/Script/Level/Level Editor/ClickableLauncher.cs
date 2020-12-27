using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableLauncher : MonoBehaviour, IPointerClickHandler
{
    public ColorLauncher colorLauncher=>new ColorLauncher (
        _color, 
        _direction,
        new Vector2Int(Mathf.CeilToInt(transform.position.x - 0.5f), Mathf.CeilToInt(transform.position.y - 0.5f)));

    [SerializeField] private SpriteRenderer spriteRenderer;

    private TileType _color;
    private Vector2Int _direction;

    private void Awake()
    {
        _color = TileType.Green;
        _direction = Vector2Int.up;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _color = _color.Next(true);
        spriteRenderer.color = colorLauncher.Color.ToColor();
    }

    public void Rotate() 
    {
       _direction = _direction.NextDirection();
        transform.rotation = Quaternion.Euler(0, 0, colorLauncher.Direction.ToAngle());
    }
}
