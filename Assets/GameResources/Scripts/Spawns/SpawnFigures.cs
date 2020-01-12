using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Создаём фигуры
/// </summary>
public class SpawnFigures : MonoBehaviour
{
    [SerializeField]
    private Transform parent = null;

    [SerializeField]
    private List<ObjectInfo> figures = new List<ObjectInfo>();

    [SerializeField]
    private float distanceBetweenFigure = 1f;

    private const float HALF = 0.5f;        

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    private void Init ()
    {
        Spawn();
    }

    /// <summary>
    /// Создаём фигуры
    /// </summary>
    private void Spawn ()
    {
        if (figures.Count == 0)
        {
            return;
        }

        float tempDistance = (figures.Count - 1) * distanceBetweenFigure;

        Vector3 newPosition = Vector3.zero;
        Vector3 startPositionCamera = Vector3.zero;

        newPosition.x = - tempDistance * HALF;
        startPositionCamera.z = - tempDistance;

        for (int i = 0; i < figures.Count; i++)
        {            
            GameObject newFigure = Instantiate(figures[i].Prefab,
                                   newPosition,
                                   Quaternion.identity,
                                   parent);

            newFigure.name = figures[i].Key;
            newFigure.GetComponent<ObjectController>().Init(figures[i]);
            EventManager.CreateFigure(figures[i]);

            newPosition.x += distanceBetweenFigure;
        }

        EventManager.CreateFigurePosition (startPositionCamera);
    }
}