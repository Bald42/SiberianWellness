using UnityEngine;

/// <summary>
/// Информация об объекте
/// </summary>
[CreateAssetMenu(fileName = "ObjectInfo", menuName = "ObjectInfo", order = 1)]
public class ObjectInfo : ScriptableObject
{
    public GameObject Prefab = null;
    public string Key = string.Empty;
    public string Name = string.Empty;
}