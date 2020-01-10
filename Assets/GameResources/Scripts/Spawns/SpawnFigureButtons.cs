using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Создаём кнопки выбора фигур
/// </summary>
public class SpawnFigureButtons : MonoBehaviour
{
    [SerializeField]
    private Transform parent = null;

    [SerializeField]
    private GameObject prefabButton = null;

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
        EventManager.OnCreateFigure += OnCreateFigure;
    }

    /// <summary>Отписки</summary>
    private void UnSubscribe()
    {
        EventManager.OnCreateFigure -= OnCreateFigure;
    }

    /// <summary>
    /// Обработчки события создания фигуры
    /// </summary>
    /// <param name="_objectInfo"></param>
    private void OnCreateFigure (ObjectInfo _objectInfo)
    {
        GameObject newButton = Instantiate(prefabButton, parent);
        newButton.name = StringKeys.KEY_BUTTON_FIGURE + "_" + _objectInfo.Key;
        newButton.GetComponent<ButtonFigure>().Init(_objectInfo);
    }
    #endregion
}