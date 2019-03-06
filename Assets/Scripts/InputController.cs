using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    public int maxJumps = 2;
    int currentJumps;

    [HideInInspector]
    public string leftAnalogX;
    [HideInInspector]
    public string leftAnalogY;
    [HideInInspector]
    public string aButton;
    [HideInInspector]
    public string bButton;
    [HideInInspector]
    public string yButton;
    [HideInInspector]
    public string xButton;
    [HideInInspector]
    public string rbButton;
    [HideInInspector]
    public string lbButton;
    [HideInInspector]
    public string startButton;



    void Start()
    {
        if (gameObject.name == "Player1")
        {
            leftAnalogX = "LeftAnalogX1";
            leftAnalogY = "LeftAnalogY1";
            xButton = "X1";
            yButton = "Y1";
            aButton = "A1";
            bButton = "B1";
            lbButton = "LB1";
            rbButton = "RB1";
            startButton = "Start1";

        }

        if (gameObject.name == "Player2")
        {
            leftAnalogX = "LeftAnalogX2";
            leftAnalogY = "LeftAnalogY2";
            xButton = "X2";
            yButton = "Y2";
            aButton = "A2";
            bButton = "B2";
            lbButton = "LB2";
            rbButton = "RB2";
            startButton = "Start2";
        }

        controller = GetComponent<CharacterController>();
        currentJumps = 0;
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            currentJumps = 0;

            moveDirection = new Vector3(Input.GetAxis(leftAnalogX), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButtonDown(xButton) || Input.GetButtonDown(yButton))
            {
                moveDirection.y = jumpSpeed;
                currentJumps++;
            }
        }

        else if (!controller.isGrounded)
        {

            if (Input.GetButtonDown(xButton) || Input.GetButtonDown(yButton))
            {
                if (currentJumps < maxJumps)
                {
                    moveDirection.y = jumpSpeed;
                    currentJumps++;
                }
            }
            moveDirection.x = Input.GetAxis(leftAnalogX) * speed;
            moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
