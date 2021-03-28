using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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

    public void startShot(Vector3 startPos, Vector3 endPos)
    {
        transform.position = startPos;
        transform.LookAt(endPos);
        Destroy(gameObject, Settings.LifeTime); //TODO need GetBack in pool!
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponentInParent<Enemy>();
        if (enemy != null)
        {
            //enemy.EnemyDeath();
            enemy.Health -= Settings.DefaultDamage;
        }
    }
}
