using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private ColorLauncherPresenter colorLauncherPrefab;
    [SerializeField] private ReflectorPresenter reflectorPresenter;

    public List<ColorLauncherPresenter> Build(LevelData data, out Tile[,] tiles)
    {
        tiles = new Tile[data.Solution.size.x, data.Solution.size.y];

        for (int x = 0; x < data.Solution.size.x; x++)
        {
            for (int y = 0; y < data.Solution.size.y; y++)
            {
                var t = Instantiate(tilePrefab);
                t.transform.position = new Vector3(x, y);
                t.SetType(data.Solution[x, y]==TileType.None? data.Solution[x, y] : TileType.Empty);
                tiles[x, y] = t;
            }
        }

        List<ColorLauncherPresenter> list = new List<ColorLauncherPresenter>();

        foreach (var l in data.ColorLaunchers)
        {
            var tmp = Instantiate(colorLauncherPrefab);
            tmp.SetLauncher(l);
            list.Add(tmp);
        }
        foreach (var r in data.Reflectors)
        {
            Instantiate(reflectorPresenter).SetReflector(r);
        }
        return list;
    }
}
