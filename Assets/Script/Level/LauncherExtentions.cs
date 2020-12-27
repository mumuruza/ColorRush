using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LauncherExtentions
{
    private static Dictionary<Vector2Int, Vector2Int> transitions = new Dictionary<Vector2Int, Vector2Int>()
    {
        { Vector2Int.right, Vector2Int.up }, 
        { Vector2Int.up, Vector2Int.left }, 
        { Vector2Int.left, Vector2Int.down }, 
        { Vector2Int.down, Vector2Int.right }, 
    };

    private static Dictionary<Vector2Int, float> angles = new Dictionary<Vector2Int, float>()
    {
        { Vector2Int.right, 270},
        { Vector2Int.up, 0},
        { Vector2Int.left, 90},
        { Vector2Int.down, 180},
        { Vector2Int.up+Vector2Int.left, 0},
        { Vector2Int.down+Vector2Int.left, 90},
        { Vector2Int.down+Vector2Int.right, 180},
        { Vector2Int.up+Vector2Int.right, 270},
    };

    public static float ToAngle(this Vector2Int vector) 
    {
        return angles[vector];
    }

    public static Vector2Int NextDirection(this Vector2Int vector)
    {
        return transitions[vector];
    }

}
