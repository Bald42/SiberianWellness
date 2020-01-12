using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Обработчик событий
/// </summary>
public static class EventManager
{
    public delegate void EmptyEventHandler();
    public static event EmptyEventHandler OnClickBack = delegate { };

    public delegate void ColorEventHandler (Color newColor);
    public static event ColorEventHandler OnChangeColor = delegate { };

    public delegate void ObjectInfoEventHandler(ObjectInfo newObjectInfo);
    public static event ObjectInfoEventHandler OnCreateFigure = delegate { };
    public static event ObjectInfoEventHandler OnSelectFigure = delegate { };

    public delegate void Vector3EventHandler (Vector3 newPosition);
    public static event Vector3EventHandler OnCreateFigurePosition = delegate { };
    public static event Vector3EventHandler OnSelectFigurePosition = delegate { };

    /// <summary>
    /// Изменили цвет
    /// </summary>
    /// <param name="_color"></param>
    public static void ChangeColor (Color _color)
    {
        OnChangeColor(_color);
    }

    /// <summary>
    /// Создаём объект
    /// </summary>
    /// <param name="_objectInfo"></param>
    public static void CreateFigure(ObjectInfo _objectInfo)
    {
        OnCreateFigure(_objectInfo);
    }

    /// <summary>
    /// Выбираем фигуру
    /// </summary>
    /// <param name="_objectInfo"></param>
    public static void SelectFigure(ObjectInfo _objectInfo)
    {
        OnSelectFigure(_objectInfo);
    }

    /// <summary>
    /// Вызываем событие по нажатию на бэк
    /// </summary>
    public static void ClickBack ()
    {
        OnClickBack();
    }

    /// <summary>
    /// Создаём объект, передаём позицию
    /// </summary>
    /// <param name="_objectInfo"></param>
    public static void CreateFigurePosition (Vector3 _position)
    {
        OnCreateFigurePosition (_position);
    }

    /// <summary>
    /// Выбираем фигуру, передаём позицию
    /// </summary>
    /// <param name="_objectInfo"></param>
    public static void SelectFigurePosition (Vector3 _position)
    {
        OnSelectFigurePosition (_position);
    }
}