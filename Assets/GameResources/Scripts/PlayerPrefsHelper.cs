using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Надстройка над PlayerPrefs
/// </summary>
public static class PlayerPrefsHelper
{
    /// <summary>
    /// Получить цвет из префсов
    /// </summary>
    /// <param name="_key"></param>
    /// <returns></returns>
    public static Color GetColor (string _key)
    {
        Color color = Color.white;

        return color;
    }

    /// <summary>
    /// Записать цвет в префсы
    /// </summary>
    /// <param name="_key"></param>
    /// <param name="_color"></param>
    /// <returns></returns>
    public static void SetColor(string _key, Color _color)
    {
        Color color = Color.white;
    }
}