using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EditorLevelPresenter : MonoBehaviour
{
    [SerializeField] private ClickableTile tilePrefab;
    [SerializeField] private Text xLabel;
    [SerializeField] private Text yLabel;
    [SerializeField] private ClickableLauncher launcherPrefab;

    private LevelData _levelData;
    private ClickableTile[,] _uiTiles = new ClickableTile[1, 1];
    private Vector2Int _levelSize = new Vector2Int(3, 3);
    private List<ClickableLauncher> _launchers = new List<ClickableLauncher>();
    private ClickableLauncher _activeLauncher;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;   
        Render();
    }

    private void Update()
    {
        if (_activeLauncher == null)
            return;
        var position = _camera.ScreenToWorldPoint(Input.mousePosition);

        _activeLauncher.transform.position = new Vector3(Mathf.Ceil(position.x-0.5f), Mathf.Ceil(position.y-0.5f));

        if (Input.GetKeyDown(KeyCode.Space))
            _activeLauncher.Rotate();
        if (Input.GetMouseButtonDown(0))
        {
            _launchers.Add(_activeLauncher);
            _activeLauncher = null;
        }
    }

    public void SetSizeX(float value)
    {
        _levelSize.x = Mathf.FloorToInt(value);
        Render();
    }

    public void SetSizeY(float value)
    {
        _levelSize.y = Mathf.FloorToInt(value);
        Render();
    }

    public void SaveLevel()
    {
        var launchers = new List<ColorLauncher>();
        foreach (var l in _launchers)
        {
            launchers.Add(l.colorLauncher);
        }
        _levelData.SetLaunchers(launchers);
        string path = UnityEditor.EditorUtility.SaveFilePanel("Save Level", "", "newLevel", "json");
        if (string.IsNullOrWhiteSpace(path))
            return;
        File.WriteAllText(path, _levelData.ToJson());
    }

    public void SpawnLauncher() 
    {
        _activeLauncher = Instantiate(launcherPrefab);
    }

    private void Render()
    {
        xLabel.text = $"X: {_levelSize.x}";
        yLabel.text = $"Y: {_levelSize.y}";

        for (int x = 0; x < _uiTiles.GetLength(0); x++)
        {
            for (int y = 0; y < _uiTiles.GetLength(1); y++)
            {
                if (_uiTiles[x, y] == null)
                    break;
                Destroy(_uiTiles[x, y].gameObject);
            }
        }

        _levelData = new LevelData(new TileType[_levelSize.x, _levelSize.y]);

        _uiTiles = new ClickableTile[_levelSize.x, _levelSize.y];

        for (int x = 0; x < _levelSize.x; x++)
        {
            for (int y = 0; y < _levelSize.y; y++)
            {
                var t = Instantiate(tilePrefab);
                t.transform.position = new Vector3(x, y);
                t.SetType(_levelData.Solution[x, y]);
                t.Init(x, y);
                t.TileClicked += OnTileClicked;
                _uiTiles[x, y] = t;
            }
        }
    }

    private void OnTileClicked(int x, int y)
    {
        _levelData.Solution.SetColor(x, y, _levelData.Solution[x, y].Next(), false);
        _uiTiles[x, y].SetType(_levelData.Solution[x, y]);
    }
}
