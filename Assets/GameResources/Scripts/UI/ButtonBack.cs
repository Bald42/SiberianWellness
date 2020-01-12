using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Кнопка назад
/// </summary>
public class ButtonBack : MonoBehaviour
{
    private Button buttonBack = null;

    private void OnEnable()
    {
        AddClick();
    }

    private void OnDestroy()
    {
        DeleteClick();
    }

    /// <summary>
    /// Выполняется при нажатии на кнопку
    /// </summary>
    private void OnClick()
    {
        EventManager.ClickBack();
    }

    /// <summary>
    /// Добавляем метод на кнопку
    /// </summary>
    private void AddClick()
    {
        buttonBack = GetComponent<Button>();
        if (buttonBack)
        {
            buttonBack.onClick.AddListener(OnClick);
        }
    }

    /// <summary>
    /// Убираем вызов с кнопки
    /// </summary>
    private void DeleteClick()
    {
        buttonBack.onClick.RemoveAllListeners();
    }
}