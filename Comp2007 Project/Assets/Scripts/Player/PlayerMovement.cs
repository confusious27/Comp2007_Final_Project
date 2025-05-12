using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    //speed of player
    public float speed = 12f;

    //gravity of player
    public float gravity = -9.81f;

    //check player is on ground and not floating about
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //adds drag to player
    Vector3 velocity;
    bool isGrounded;



    public bool canMove = false;

    void Update()
    {
        //stops movement while animation plays
        if (!canMove) return;

        //checks for the floor
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //forces player to back to the ground when there is no ground below
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //player movement
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis ("Vertical");

        Vector3 move = transform.right * hor + transform.forward * ver;

        controller.Move(move * speed * Time.deltaTime);

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
