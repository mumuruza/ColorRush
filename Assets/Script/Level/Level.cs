using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelBuilder levelBuilder;
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private PreviewBuilder previewBuilder;

    private Tile[,] _tiles;
    private LevelData _levelData;

    private void Start()
    {
        _levelData = CurrentLevel.GetCurrentLevel();
        previewBuilder.BuildPreview(_levelData);
        var launchers = levelBuilder.Build(_levelData, out _tiles);
        foreach (var l in launchers)
        {
            l.LauncherClicked += LaunchBall;
        }
    }

    private void LaunchBall(ColorLauncher from)
    {
        var ball = Instantiate(ballPrefab);
        ball.Init(from.Direction, from.Position, _levelData, from.Color);
        ball.TileReached += ColorTile;
        ball.Destroyed += CheckField;
    }

    private void CheckField()
    {
        for (int x = 0; x < _levelData.Solution.size.x; x++)
        {
            for (int y = 0; y < _levelData.Solution.size.y; y++)
            {
                if (_levelData.Solution[x, y] != _tiles[x, y].TileType)
                    return;
            }
        }
        LevelCompleted();
    }

    private void LevelCompleted() 
    {
        CurrentLevel.ReportLevelDone();
        SceneManager.LoadScene(0);
    }

    private void ColorTile(Vector2Int position, TileType color)
    {
        if (_tiles[position.x, position.y].TileType == TileType.None)
            return;
        _tiles[position.x, position.y].SetType(color);
    }
}
