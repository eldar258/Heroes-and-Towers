using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public static HeroManager instance = null;
    public Player Player;
    public List<GunObjects> GunSettings;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
