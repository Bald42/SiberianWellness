using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер интерфейса
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField]
    private ActiveWindow windowColorButton = null;

    [SerializeField]
    private ActiveWindow windowFigureButton = null;

    [SerializeField]
    private ActiveWindow windowBackButton = null;

    #region Subscribes / UnSubscribes
    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        UnSubscribe();
    }

    /// <summary>Подписки</summary>
    private void Subscribe()
    {
        EventManager.OnSelectFigure += OnSelectFigure;
        EventManager.OnClickBack += OnClickBack;
    }

    /// <summary>Отписки</summary>
    private void UnSubscribe()
    {
        EventManager.OnSelectFigure -= OnSelectFigure;
        EventManager.OnClickBack -= OnClickBack;
    }

    /// <summary>
    /// Обработчик события выбора фигуры
    /// </summary>
    private void OnSelectFigure (ObjectInfo empty)
    {
        OnFigure();
    }

    /// <summary>
    /// Обработчик события нажатия кнопки бэк
    /// </summary>
    private void OnClickBack ()
    {
        OnBack();
    }
    #endregion

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