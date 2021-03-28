using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Singelton. Производитель пуль
/// </summary>
public class BulletSpawner : MonoBehaviour
{
    /// <summary>
    /// Префаб пули
    /// </summary>
    public GameObject BulletPrefab;
    /// <summary>
    /// Размер пула пуль
    /// </summary>
    public int countPool;

    /// <summary>
    /// Singelton
    /// </summary>
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
    /// <summary>
    /// Берет пулю из пула и активирует
    /// </summary>
    /// <param name="startPos">Место появления пули</param>
    /// <param name="endPos">Направление пули</param>
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
