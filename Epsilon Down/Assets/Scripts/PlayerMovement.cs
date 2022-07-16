using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float speed = 12;
    Vector3 velocity;
    bool isGrounded;
    public float gravity = -105.37f;
    public float jumpHeight = 4.5f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        // The Abilities and Stuff

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            jumpHeight = 4.5f;
            speed = 12f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            jumpHeight = 1.5f;
            speed = 24;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            jumpHeight = 2;
            speed = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            jumpHeight = 9;
            speed = 5;
        }
    }
}
