using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;
    public int countPool;


    public static BulletSpawner instance = null;

    private Queue<Bullet> bulletsPool;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        bulletsPool = new Queue<Bullet>(countPool);
        fillQueue();
    }

    public void createBullet(Vector3 startPos, Vector3 endPos)
    {
        if (bulletsPool.Count == 0) fillQueue();
        Bullet bullet = bulletsPool.Dequeue();
        bullet.SetActive(true);
        bullet.startShot(startPos, endPos);
    }

    private void fillQueue()
    {
        for (int i = 0; i < countPool; i++)
        {
            GameObject newBulletObject = Instantiate(BulletPrefab);
            Bullet newBullet = newBulletObject.GetComponent<Bullet>();
            newBullet.SetActive(false);
            bulletsPool.Enqueue(newBullet);
        }
    }
}
