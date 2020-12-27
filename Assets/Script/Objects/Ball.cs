using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector2Int _direction;
    private Vector2Int _currentPosition;
    private LevelData _levelData;
    private TileType _color;

    public event Action<Vector2Int, TileType> TileReached;
    public event Action Destroyed;

    public void Init(Vector2Int direction, Vector2Int currentPosition, LevelData levelData, TileType color)
    {
        _direction = direction;
        _currentPosition = currentPosition;
        _levelData = levelData;
        _color = color;
        spriteRenderer.color = _color.ToColor();
        transform.position = new Vector3(currentPosition.x, currentPosition.y);
    }

    private void Update()
    {
        var targetPosition = new Vector3((_currentPosition + _direction).x, (_currentPosition + _direction).y);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
        if (transform.position == targetPosition)
        {
            _currentPosition += _direction;
            TileReached?.Invoke(_currentPosition, _color);
            var reflector = _levelData.Reflectors.Find(x => x.Position == _currentPosition);
            if(reflector!=null)
            {
                _direction = reflector.CalculateDirection(_direction);
            }
            var nextPosition = _currentPosition + _direction;
            if (nextPosition.x < 0 || nextPosition.y < 0 || nextPosition.x >= _levelData.Solution.size.x || nextPosition.y >= _levelData.Solution.size.y)
            {
                Destroyed?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
