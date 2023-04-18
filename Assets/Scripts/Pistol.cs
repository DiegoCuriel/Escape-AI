using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    public float fireRate = 0.5f;
    private float timeSinceLastShot = 0f;

    void shoot()
    {
        Quaternion rotation = Quaternion.Euler(0, -75, 0);

        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.forward * bulletSpeed;
    }

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timeSinceLastShot >= fireRate)
        {
            shoot();
            timeSinceLastShot = 0f;
        }
    }
}
