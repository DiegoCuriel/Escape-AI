using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public string maloTag = "Malo";

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(maloTag))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
