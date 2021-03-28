using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Singleton. Позволяет получить доступ к герою и соответсвующим настройкам
/// </summary>
public class HeroManager : MonoBehaviour
{
    /// <summary>
    /// Singleton
    /// </summary>
    public static HeroManager instance = null;
    /// <summary>
    /// Игрок
    /// </summary>
    public Player Player;
    /// <summary>
    /// Все возможные оружия
    /// </summary>
    public List<GunObjects> GunSettings;
    /// <summary>
    /// Текущее оружие у игрока
    /// </summary>
    public GunObjects CurrentGunSetting;


    private Dictionary<string, GunObjects> guns = new Dictionary<string, GunObjects>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        foreach (var el in GunSettings) {
            guns.Add(el.Name, el);
        }
        CurrentGunSetting = guns["Hend"];
    }
}
