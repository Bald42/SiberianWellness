using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер звуков
/// </summary>
public class SoundPlayer : MonoBehaviour
{
    public static SoundPlayer Instance = null;

    private AudioSource audioSource = null;

    [SerializeField]
    private AudioClip clipClick = null;

    [SerializeField]
    private AudioClip clipArfa = null;

    private void Awake()
    {
        Init();
    }

    private void OnDestroy()
    {
        InitInstance(null);
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    private void Init ()
    {
        audioSource = GetComponent<AudioSource>();
        InitInstance(this);
    }

    /// <summary>
    /// Инициализаруем делегат
    /// </summary>
    /// <param name="_instance"></param>
    private void InitInstance (SoundPlayer _instance)
    {
        Instance = _instance;
    }

    /// <summary>
    /// Воспроизведение звука клика
    /// </summary>
    public void PlayClick(float _value)
    {
        audioSource.PlayOneShot(clipClick, _value);
    }

    /// <summary>
    /// Воспроизведение звука клика
    /// </summary>
    public void PlayClick ()
    {
        PlayClick(1f);
    }

    /// <summary>
    /// Воспроизведение звука арфы
    /// </summary>
    public void PlayArfa ()
    {
        PlayArfa(1f);
    }

    /// <summary>
    /// Воспроизведение звука арфы
    /// </summary>
    public void PlayArfa(float _value)
    {
        audioSource.PlayOneShot(clipArfa, _value);
    }
}