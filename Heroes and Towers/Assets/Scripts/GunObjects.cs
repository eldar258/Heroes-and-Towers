using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Настройки оружия для хранения в файле
/// </summary>
[CreateAssetMenu(fileName = "GunObjects", menuName = "ScriptableObjects/GunScriptableObject")]
public class GunObjects : ScriptableObject
{
    /// <summary>
    /// Название оружия
    /// </summary>
    public string Name = "Default";
    /// <summary>
    /// Время в секундах на один выстрел
    /// </summary>
    public float SecondForShot = 0.6f;
}