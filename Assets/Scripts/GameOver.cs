using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    void Start()
    {
        Invoke("CargarMenu", 2.0f);
    }

    void CargarMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
