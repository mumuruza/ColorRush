using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewBuilder : MonoBehaviour
{
    [SerializeField] private Image cellPrefab;
    [SerializeField] private GridLayoutGroup grid;

    public void BuildPreview(LevelData levelData)
    {
        grid.constraintCount = levelData.Solution.size.y;
        for (int y = 0; y < levelData.Solution.size.y; y++)
        {
            for (int x = 0; x < levelData.Solution.size.x; x++)
            {
                Instantiate(cellPrefab, grid.transform).color = levelData.Solution[x, y].ToColor();

            }
        }
    }
}
