using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorPresenter : MonoBehaviour
{
    private Reflector _reflector;

    private void Awake()
    {
        SetReflector(new Reflector(Vector2Int.left + Vector2Int.down, Vector2Int.zero));
    }

    public void SetReflector(Reflector reflector)
    {
        _reflector = reflector;
        transform.rotation = Quaternion.Euler(0, 0, _reflector.Direction.ToAngle());
        transform.position = new Vector3(_reflector.Position.x, _reflector.Position.y);
    }
}
