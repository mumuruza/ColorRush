using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLevel 
{
    private static string _levelIndexKey = "Current Level";
    private static int index = PlayerPrefs.GetInt(_levelIndexKey, 0);
    private static int Index 
    { 
        get 
        {
            if (index < 0) 
            {
                index = PlayerPrefs.GetInt(_levelIndexKey, 0);
            }
            return index;
        } 
        set 
        {
            index = value;
            PlayerPrefs.SetInt(_levelIndexKey, index);
        } 
    }

    public static LevelData GetCurrentLevel() 
    {
        var level = Resources.Load<TextAsset>($"Levels/level_{Index}");
        if (level == null)
        {
            Index = 0;
            return GetCurrentLevel();
        }
        return LevelData.FromJson(level.text);
    }

    public static void ReportLevelDone()
    {
        Index++;
    }
}
