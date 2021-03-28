using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Место, где игрок может стрелять (переходит в режим стрельбы)
/// </summary>
public class ShootingPlatform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (other.CompareTag("Player"))
        {
            player.SetState<StateShoot>();
        }
    }
}
