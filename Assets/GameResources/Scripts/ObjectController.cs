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
    }

    /// <summary>Отписки</summary>
    private void UnSubscribe()
    {
        EventManager.OnChangeColor -= OnChangeColor;
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
        }
    }
    #endregion

    /// <summary>
    /// Инициализируем объект
    /// </summary>
    public void Init (ObjectInfo _objectInfo)
    {
        objectInfo = _objectInfo;
        material = GetComponent<MeshRenderer>().material;
        isActive = false;
    }
}