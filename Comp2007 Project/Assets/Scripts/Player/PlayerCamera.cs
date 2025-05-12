using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    //speed of mouse
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    
    void Start()
    {
        //ensures cursor starts in middle of screen and is invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public bool canMove = false;

    void Update()
    {

        //stops camera movement from player while animation plays
        if (!canMove) return;

        //get mouse input for looking
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        Debug.Log("MouseY: " + mouseY);

        xRotation -= mouseY;

        //clamping x rotation to 90 degrees so players don't break their necks
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //rotate cam along x axis
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //rotate player towards direction
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
