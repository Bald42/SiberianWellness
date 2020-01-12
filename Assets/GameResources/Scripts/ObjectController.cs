﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт обрабатывающий поведение объекта
/// </summary>
public class ObjectController : MonoBehaviour
{
    private AnimScale animScale = null;
    private ObjectInfo objectInfo = null;
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
        EventManager.OnClickBack += OnClickBack;
    }

    /// <summary>Отписки</summary>
    private void UnSubscribe()
    {
        EventManager.OnChangeColor -= OnChangeColor;
        EventManager.OnSelectFigure -= OnSelectFigure;
        EventManager.OnClickBack -= OnClickBack;

    }

    /// <summary>
    /// Обработчик события изменения цвета
    /// </summary>
    /// <param name="_color"></param>
    private void OnChangeColor (Color _color)
    {
        if (isActive)
        {
            if (material.color != _color)
            {
                SoundPlayer.Instance.PlayArfa(0.8f);
                material.color = _color;
                PlayerPrefsHelper.SetColor(objectInfo.Key, _color);
            }
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
            EventManager.SelectFigurePosition(transform.position);
        }
        else
        {
            animScale.Active(false);
            isActive = false;
        }
    }

    /// <summary>
    /// Обработчик события нажатия на бэк
    /// </summary>
    private void OnClickBack ()
    {
        animScale.Active(true);
    }
    #endregion

    /// <summary>
    /// Инициализируем объект
    /// </summary>
    public void Init(ObjectInfo _objectInfo)
    {
        objectInfo = _objectInfo;
        material = GetComponent<MeshRenderer>().material;
        animScale = GetComponent<AnimScale>();
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