using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float walkSpeed = 5f;

    public float runSpeed = 6f;

    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform groundCheck;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    bool isGrounded;

    public float jumpHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Jump "space"
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * walkSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //When pressing the "W" and "Q" keys on the keyboard at the same time, enter the running mode
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.Q))
        {
            controller.Move(move * runSpeed * Time.deltaTime);
        }

    }
}
