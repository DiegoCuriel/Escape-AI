using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;
    public string indestructibleTag = "Indestructible";
    public string WinTag = "Win";

    void Awake()
    {
        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(indestructibleTag) | collision.gameObject.CompareTag(WinTag))
        {}
        else
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
