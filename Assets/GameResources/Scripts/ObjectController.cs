using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт обрабатывающий поведение объекта
/// </summary>
public class ObjectController : MonoBehaviour
{
    [SerializeField]
    private ObjectInfo objectInfo = null;

    [SerializeField]
    private bool isActive = true;

    private Material material = null;

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
    private void OnChangeColor (Color _color)
    {
        if (isActive)
        {
            material.color = _color;
            PlayerPrefsHelper.SetColor(objectInfo.Key, _color);
        }
    }

    /// <summary>
    /// Обработчик события выбора фигуры
    /// </summary>
    /// <param name="_objectInfo"></param>
    private void OnSelectFigure (ObjectInfo _objectInfo)
    {
        if (_objectInfo == objectInfo)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }
    #endregion

    /// <summary>
    /// Инициализируем объект
    /// </summary>
    public void Init(ObjectInfo _objectInfo)
    {
        objectInfo = _objectInfo;
        material = GetComponent<MeshRenderer>().material;
        isActive = false;
        CheckColor();
    }

    /// <summary>
    /// Применяем цвет если он сохранён для этого объекта
    /// </summary>
    private void CheckColor ()
    {
        if (PlayerPrefsHelper.HasKeyColor(objectInfo.Key))
        {
            material.color = PlayerPrefsHelper.GetColor(objectInfo.Key);
        }
    }
}