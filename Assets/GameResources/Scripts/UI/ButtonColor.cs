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

    [SerializeField]
    private ActiveWindow iconMark = null;

    #region Subscribes / UnSubscribes
    private void OnEnable()
    {
        Subscribe();
        AddClick();
    }

    private void OnDisable()
    {
        UnSubscribe();
        DeleteClick();
    }

    /// <summary>Подписки</summary>
    private void Subscribe()
    {
        EventManager.OnChangeColor += OnChangeColor;
        EventManager.OnSelectFigure += OnSelectFigure;
    }

    /// <summary>Отписки</summary>
    private void UnSubscribe()
    {
        EventManager.OnChangeColor -= OnChangeColor;
        EventManager.OnSelectFigure -= OnSelectFigure;
    }

    /// <summary>
    /// Обработчик события изменения цвета
    /// </summary>
    /// <param name="_color"></param>
    private void OnChangeColor(Color _color)
    {
        if (color == _color)
        {
            iconMark.Active(true);
        }
        else
        {
            iconMark.Active(false);
        }
    }

    /// <summary>
    /// Обработчик события выбора фигуры
    /// </summary>
    /// <param name="_objectInfo"></param>
    private void OnSelectFigure(ObjectInfo _objectInfo)
    {
        iconMark.Active(false, false);
        if (PlayerPrefsHelper.HasKeyColor(_objectInfo.Key))
        {
            if (color == PlayerPrefsHelper.GetColor(_objectInfo.Key))
            {
                iconMark.Active(true, false);
            }
        }
    }
    #endregion

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
        iconMark.Active(false, false);
    }

    /// <summary>
    /// Метод выполняется при нажатии на кнопку
    /// </summary>
    private void OnClick()
    {
        EventManager.ChangeColor(color);
    }
}