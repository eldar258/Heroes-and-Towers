using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunObjects", menuName = "ScriptableObjects/GunScriptableObject")]
public class GunObjects : ScriptableObject
{
    public string Name = "Default";
    public float SecondForShot = 0.6f;
}