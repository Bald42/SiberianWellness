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
        color.r = PlayerPrefs.GetFloat(_key + "_Color_R");
        color.g = PlayerPrefs.GetFloat(_key + "_Color_G");
        color.b = PlayerPrefs.GetFloat(_key + "_Color_B");
        color.a = PlayerPrefs.GetFloat(_key + "_Color_A");
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
        PlayerPrefs.SetFloat(_key + "_Color_R", _color.r);
        PlayerPrefs.SetFloat(_key + "_Color_G", _color.g);
        PlayerPrefs.SetFloat(_key + "_Color_B", _color.b);
        PlayerPrefs.SetFloat(_key + "_Color_A", _color.a);
        PlayerPrefs.Save();
    }
}