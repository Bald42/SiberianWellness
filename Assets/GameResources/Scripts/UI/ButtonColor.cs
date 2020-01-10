using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Кнопка выбора цвета
/// </summary>
public class ButtonColor : MonoBehaviour
{   
    private Color color = Color.white;

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
    private void AddClick ()
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
    private void DeleteClick ()
    {
        if (button)
        {
            GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }

    /// <summary>
    /// Инициализация кнопки изменения цвета
    /// </summary>
    public void Init (Color _color)
    {
        color = _color;
        GetComponent<Image>().color = color;
    }

    /// <summary>
    /// Метод выполняется при нажатии на кнопку
    /// </summary>
    private void OnClick()
    {
        EventManager.ChangeColor(color);
    }
}