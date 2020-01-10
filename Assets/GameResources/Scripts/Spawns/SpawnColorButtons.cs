using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Создаём кнопки цветов
/// </summary>
public class SpawnColorButtons : MonoBehaviour
{
    [SerializeField]
    private ColorsInfo colorsInfo = null;

    [SerializeField]
    private GameObject prefabButton = null;

    [SerializeField]
    private Transform parentObject = null;

    private void Awake()
    {
        Spawn();
    }

    /// <summary>
    /// Создаём кнопки
    /// </summary>
    private void Spawn ()
    {
        if (colorsInfo && colorsInfo.Colors.Count > 0)
        {
            for (int i=0; i < colorsInfo.Colors.Count; i++)
            {
                GameObject newButton = Instantiate(prefabButton,parentObject);
                newButton.name = newButton.name.Replace(StringKeys.KEY_CLONE, "_" + i.ToString());
                newButton.GetComponent<ButtonColor>().Init(colorsInfo.Colors[i]);
            }
        }
    }
}