using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Настройки пули для хранения в файле
/// </summary>
[CreateAssetMenu(fileName = "BulletObjects", menuName = "ScriptableObjects/BulletScriptableObject", order = 1)]
public class BulletObjects : ScriptableObject
{
    public float Speed = 1;
    public float LifeTime = 7;
    public float DefaultDamage = 25;
    /// <summary>
    /// Сила импульса при попадании
    /// </summary>
    public float ImpulseCollision = 10;
    public GameObject ParticleStartShot;
    public GameObject ParticleTrail;
    public GameObject ParticleEndShot;
}
