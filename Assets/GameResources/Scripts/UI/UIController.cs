using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер интерфейса
/// </summary>
public class UIController : MonoBehaviour
{
    //TODO переделать на события
    [SerializeField]
    private ActiveWindow windowColorButton = null;

    [SerializeField]
    private ActiveWindow windowFigureButton = null;

    [SerializeField]
    private ActiveWindow windowBackButton = null;

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    private void Init ()
    {
        windowColorButton.Active(false, false);
        windowBackButton.Active(false, false);
        windowFigureButton.Active(true, false);
    }

    /// <summary>
    /// Нажатие по кнопке бэк
    /// </summary>
    public void OnBack ()
    {
        windowColorButton.Active(false);
        windowBackButton.Active(false);
        windowFigureButton.Active(true);
    }

    /// <summary>
    /// Выбор фигуры
    /// </summary>
    public void OnFigure ()
    {
        windowColorButton.Active(true);
        windowBackButton.Active(true);
        windowFigureButton.Active(false);
    }
}