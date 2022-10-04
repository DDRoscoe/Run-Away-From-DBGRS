using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity;       // for gravity
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);     // ground check ensures velocity doesn't constantly increase

        if(isGrounded && velocity.y < 0 )
        {
            velocity.y = -2f;   // setting to -2 instead of 0 works better for triggering a fall, but both work
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // X and Z movement
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Y movement (gravity)
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
