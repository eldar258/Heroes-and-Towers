using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Логика пули
/// </summary>
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// Настройки для пули
    /// </summary>
    public BulletObjects Settings;

    private Rigidbody rb;
    private Vector3 destination;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * Settings.Speed);
    }
    /// <summary>
    /// Пуля летит из startPos в endPos
    /// </summary>
    /// <param name="startPos">Место появления</param>
    /// <param name="endPos">Направление</param>
    public void startShot(Vector3 startPos, Vector3 endPos)
    {
        transform.position = startPos;
        transform.LookAt(endPos);
        Destroy(gameObject, Settings.LifeTime); //TODO need GetBack in pool!

        Destroy(Instantiate(Settings.ParticleStartShot, transform.position, transform.rotation)
            , Settings.LifeTime);
        
        Instantiate(Settings.ParticleTrail, transform.position, transform.rotation, transform);
    }
    /// <summary>
    /// Активация или деактивация объекта
    /// </summary>
    /// <param name="isActive"></param>
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            enemy.Health -= Settings.DefaultDamage;
            collision.rigidbody.AddForce(transform.forward * Settings.ImpulseCollision, ForceMode.Impulse);
            Instantiate(Settings.ParticleEndShot, transform.position, transform.rotation, transform);
        }
    }
}
