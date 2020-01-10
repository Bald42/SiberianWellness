using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Обработчик событий
/// </summary>
public static class EventManager
{
    public delegate void ColorEventHandler (Color newColor);
    public static event ColorEventHandler OnChangeColor = delegate { };

    /// <summary>
    /// Изменили цвет
    /// </summary>
    /// <param name="_color"></param>
    public static void ChangeColor (Color _color)
    {
        OnChangeColor(_color);
    }
}