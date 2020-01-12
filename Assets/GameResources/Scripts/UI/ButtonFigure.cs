using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Кнопка выбора фигуры
/// </summary>
public class ButtonFigure : MonoBehaviour
{
    private ObjectInfo objectInfo = null;

    private Text textButton = null;

    private Button buttonFigure = null;

    /// <summary>
    /// Инициализируем объект
    /// </summary>
    public void Init(ObjectInfo _objectInfo)
    {
        objectInfo = _objectInfo;

        buttonFigure = GetComponent<Button>();
        textButton = GetComponentInChildren<Text>();

        textButton.text = objectInfo.Name;
        buttonFigure.onClick.AddListener(OnClick);
    }

    /// <summary>
    /// Выполняется при нажатии на кнопку
    /// </summary>
    private void OnClick ()
    {
        EventManager.SelectFigure(objectInfo);
    }

    private void OnDestroy()
    {
        UnSubscribeButton();
    }

    /// <summary>
    /// Убираем вызов с кнопки
    /// </summary>
    private void UnSubscribeButton ()
    {
        buttonFigure.onClick.RemoveAllListeners();
    }
}