using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Воспроизводим партикль
/// </summary>
public class PlayParticle : MonoBehaviour
{
    private ParticleSystem particleSystem = null;

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
        EventManager.OnCheckNewColor += OnCheckNewColor;
    }

    /// <summary>Отписки</summary>
    private void UnSubscribe()
    {
        EventManager.OnCheckNewColor -= OnCheckNewColor;
    }

    /// <summary>
    /// Обработчик события применения нового цвета фигуры
    /// </summary>
    private void OnCheckNewColor (Vector3 _position, Color _color)
    {
        transform.position = _position;
        particleSystem.startColor = _color;
        particleSystem.Play();
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
        particleSystem = GetComponent<ParticleSystem>();
    }
}