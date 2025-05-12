using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    //sensitivity
    public float sensX;
    public float sensY;

    //player orientation
    public Transform orientation;

    //camera rotation
    float xRotate;
    float yRotate;

    private void Start()
    {
        //ensures cursor starts in middle of screen and is invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotate += mouseX;
        xRotate -= mouseY;

        //clamping x rotation to 90 degrees so players don't break their necks
        xRotate = Mathf.Clamp(xRotate, -90f, 90f);

        //rotate cam and orientation
        //to rotate camera along both axis
        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);

        //rotate player along the y axis
        orientation.rotation = Quaternion.Euler(0, yRotate, 0);
    }
}
