using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    bool time_stop = false;
    public Rigidbody rb;

    void Update()
    {
        if (!time_stop)
        {
            Time.timeScale = 1;
            PlayerMovement.movementSpeed = 6;
            
            if (rb.velocity.magnitude == 0)
            {
                time_stop = true;
            }
        }
        else
        {
            Time.timeScale = 0.01f;
            PlayerMovement.movementSpeed = 60;

            if (rb.velocity.magnitude != 0)
            {
                time_stop = false;
            }
        }
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
