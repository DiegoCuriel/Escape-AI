using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField]
    private float senX;
    
    [SerializeField]
    private float senY;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;
    public Camera cam;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MyInput();

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * senX * multiplier;
        xRotation -= mouseY * senY * multiplier;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}