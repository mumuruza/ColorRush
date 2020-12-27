using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColorLauncherPresenter : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    private ColorLauncher _colorLauncher;

    public event Action<ColorLauncher> LauncherClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        LauncherClicked?.Invoke(_colorLauncher);
    }

    public void SetLauncher(ColorLauncher colorLauncher)
    {
        _colorLauncher = colorLauncher;
        spriteRenderer.color = colorLauncher.Color.ToColor();
        transform.rotation = Quaternion.Euler(0, 0, colorLauncher.Direction.ToAngle());
        transform.position = new Vector3(colorLauncher.Position.x, colorLauncher.Position.y);
    }
}
