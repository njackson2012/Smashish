using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Input : MonoBehaviour
{

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    public int maxJumps = 2;
    int currentJumps;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentJumps = 0;
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            currentJumps = 0;

            moveDirection = new Vector3(Input.GetAxis("LeftAnalogX2"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButtonDown("X2") || Input.GetButtonDown("Y2"))
            {
                moveDirection.y = jumpSpeed;
                currentJumps++;
            }
        }

        else if (!controller.isGrounded)
        {

            if (Input.GetButtonDown("X2") || Input.GetButtonDown("Y2"))
            {
                if (currentJumps < maxJumps)
                {
                    moveDirection.y = jumpSpeed;
                    currentJumps++;
                }
            }
            moveDirection.x = Input.GetAxis("LeftAnalogX2") * speed;
            moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
