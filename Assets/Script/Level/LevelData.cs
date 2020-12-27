using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    [System.Serializable]
    private class LevelSave
    {
        public TileType[,] map;
        public List<ColorLauncher> ColorLaunchers;
        public List<Reflector> Reflectors;
    }

    public static LevelData FromJson(string json) 
    {
        var save = JsonConvert.DeserializeObject<LevelSave>(json);
        return new LevelData(save.map)
        {
            _colorLaunchers = save.ColorLaunchers,
            _reflectors = save.Reflectors
        };
    }

    public LevelMap Solution;

    public IReadOnlyCollection<ColorLauncher> ColorLaunchers => _colorLaunchers;
    public List<Reflector> Reflectors => _reflectors;

    private List<ColorLauncher> _colorLaunchers;
    private List<Reflector> _reflectors;

    public LevelData(TileType[,] map) 
    {
        Solution = new LevelMap(map);
    }

    public void SetLaunchers(List<ColorLauncher> colorLaunchers)
    {
        _colorLaunchers = colorLaunchers;
    }

    public string ToJson() 
    {
        var save = new LevelSave()
        {
            map = Solution.MapClone(),
            ColorLaunchers = _colorLaunchers,
            Reflectors = _reflectors
        };
        return JsonConvert.SerializeObject(save);
    }
}
