using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    bool time_stop = false;

    void Update()
    {
        if (!time_stop && !Input.anyKey)
        {
            Time.timeScale = 0.1f;
            time_stop = true;
        }
        else if (time_stop && Input.anyKey)
        {
            Time.timeScale = 1f;
            time_stop = false;
        }
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
