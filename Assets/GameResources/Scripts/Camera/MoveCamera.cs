using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Обработчик движения камеры
/// </summary>
public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private Transform transformCamera = null;

    [SerializeField]
    private Vector3 vectorDisplacementStart = new Vector3(0f, 4f, 0f);

    [SerializeField]
    private Vector3 vectorDisplacementFigure = new Vector3(0f, 2f, -8f);

    private Vector3 startPosition = Vector3.zero;
    private Vector3 figurePosition = Vector3.zero;
    private Vector3 figurePositionCamera = Vector3.zero;

    private Quaternion startRotation = Quaternion.identity;

    private Coroutine coroutineMoveToStart = null;
    private Coroutine coroutineMoveToFigure = null;
    private Coroutine coroutineRotationAround = null;
    private Coroutine coroutineRotationStart = null;

    private const float MIN_DISTANCE = 0.01f;

    private const float SPEED_MOVE = 2f;
    private const float SPEED_ROTATION = -15f;

    private enum TypeCamMove
    {
        Non,
        StartPos,
        MoveToFigure,
        MoveAroundFigure
    }

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
        EventManager.OnCreateFigurePosition += OnCreateFigurePosition;
        EventManager.OnSelectFigurePosition += OnSelectFigurePosition;
        EventManager.OnClickBack += OnClickBack;
    }

    /// <summary>Отписки</summary>
    private void UnSubscribe()
    {
        EventManager.OnCreateFigurePosition -= OnCreateFigurePosition;
        EventManager.OnSelectFigurePosition -= OnSelectFigurePosition;
        EventManager.OnClickBack -= OnClickBack;
    }

    /// <summary>
    /// Обработчик события создания фигур
    /// </summary>
    /// <param name="_vector3"></param>
    private void OnCreateFigurePosition(Vector3 _vector3)
    {
        startPosition = _vector3 + vectorDisplacementStart;
        coroutineMoveToStart = StartCoroutine(MoveToStart(1f));
    }

    /// <summary>
    /// Обработчик события выбора фигуры
    /// </summary>
    private void OnSelectFigurePosition(Vector3 _vector3)
    {
        figurePosition = _vector3;
        figurePositionCamera = figurePosition + vectorDisplacementFigure;
        CheckStopCoroutine(coroutineMoveToStart);
        coroutineMoveToFigure = StartCoroutine(MoveToFigure());
    }

    /// <summary>
    /// Обработчик события нажатия кнопки бэк
    /// </summary>
    private void OnClickBack()
    {
        CheckStopCoroutine(coroutineMoveToFigure);
        CheckStopCoroutine(coroutineRotationAround);
        CheckStopCoroutine(coroutineRotationStart);
        coroutineRotationStart = StartCoroutine(RotationStart());
        coroutineMoveToStart = StartCoroutine(MoveToStart(0f));
    }
    #endregion

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// Инициализация
    /// </summary>
    private void Init()
    {
        startRotation = transformCamera.rotation;
        transformCamera.position = Vector3.zero + vectorDisplacementStart;
    }

    /// <summary>
    /// Проверяем можео стопать карутину
    /// </summary>
    /// <param name="_coroutine"></param>
    private void CheckStopCoroutine(Coroutine _coroutine)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    /// <summary>
    /// Перемещаемся к стартовой позиции
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveToStart(float _startDelay)
    {
        bool _isMove = true;
        yield return new WaitForSecondsRealtime(_startDelay);
        while (_isMove)
        {
            transformCamera.position = Vector3.Lerp(transformCamera.position,
                                       startPosition,
                                       Time.unscaledDeltaTime * SPEED_MOVE);
            if ((transformCamera.position - startPosition).sqrMagnitude <= MIN_DISTANCE)
            {
                transformCamera.position = startPosition;
                _isMove = false;
            }
            yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
        }
    }

    /// <summary>
    /// Перемещаемся к фигуре
    /// </summary>
    /// <returns></returns>
    private IEnumerator MoveToFigure()
    {
        bool _isMove = true;
        while (_isMove)
        {
            transformCamera.position = Vector3.Lerp(transformCamera.position,
                                       figurePositionCamera,
                                       Time.unscaledDeltaTime * SPEED_MOVE);
            if ((transformCamera.position - figurePositionCamera).sqrMagnitude <= MIN_DISTANCE)
            {
                //transformCamera.position = figurePositionCamera;
                CheckStopCoroutine(coroutineRotationAround);
                CheckStopCoroutine(coroutineRotationStart);
                coroutineRotationAround = StartCoroutine(RotationAroundFigure());
                _isMove = false;
            }
            yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
        }
    }

    /// <summary>
    /// Вращение вокруг фигуры
    /// </summary>
    /// <returns></returns>
    private IEnumerator RotationAroundFigure ()
    {
        while (true)
        {
            transformCamera.RotateAround(figurePosition, Vector3.up, Time.unscaledDeltaTime * SPEED_ROTATION);
            yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
        }
    }

    /// <summary>
    /// Вращение вокруг фигуры
    /// </summary>
    /// <returns></returns>
    private IEnumerator RotationStart()
    {
        bool _isMove = true;

        while (_isMove)
        {
            transformCamera.rotation = Quaternion.Lerp(transformCamera.rotation,
                                       startRotation,
                                       Time.unscaledDeltaTime * SPEED_MOVE);
            if ((transformCamera.rotation.eulerAngles - startRotation.eulerAngles).sqrMagnitude 
                <= MIN_DISTANCE)
            {
                transformCamera.rotation = startRotation;
                _isMove = false;
            }
            yield return new WaitForSecondsRealtime(Time.unscaledDeltaTime);
        }
    }
}