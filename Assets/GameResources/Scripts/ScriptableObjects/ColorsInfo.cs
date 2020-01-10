using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Информация об объекте
/// </summary>
[CreateAssetMenu(fileName = "ColorsInfo", menuName = "ColorsInfo", order = 1)]
public class ColorsInfo : ScriptableObject
{
    public List<Color> Colors = new List<Color>();
}