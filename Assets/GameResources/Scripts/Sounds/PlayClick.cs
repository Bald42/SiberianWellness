using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Воспроизведение звука клика
/// </summary>
public class PlayClick : MonoBehaviour
{
    private Button button = null;

    private void OnEnable()
    {
        AddClick();
    }

    private void OnDisable()
    {
        DeleteClick();
    }

    /// <summary>
    /// Добавляем метод на кнопку
    /// </summary>
    private void AddClick()
    {
        button = GetComponent<Button>();
        if (button)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    /// <summary>
    /// Удаляем метод с кнопки
    /// </summary>
    private void DeleteClick()
    {
        if (button)
        {
            GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    /// <summary>
    /// Метод выполняется при нажатии на кнопку
    /// </summary>
    private void OnClick()
    {
        SoundPlayer.Instance.PlayClick();
    }
}