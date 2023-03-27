using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPistol : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public float fireRate = 1f;
    private float nextFireTime = 0.0f;

    void shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
}
