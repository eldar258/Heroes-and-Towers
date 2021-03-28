using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletObjects", menuName = "ScriptableObjects/BulletScriptableObject", order = 1)]
public class BulletObjects : ScriptableObject
{
    public float Speed = 1;
    public float LifeTime = 7;
    public float DefaultDamage = 25;
    public float ImpulseCollision = 10;
}
