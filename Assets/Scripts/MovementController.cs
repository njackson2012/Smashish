using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    //private PlayerAnimation
    private Animator anim;

    private CharacterController controller;
    private Transform playerOneTransform;
    private Vector3 moveDirection = Vector3.zero;
	private CombatController stateMachine;
    public float walkSpeed = 6.0f;
    public float jumpHeight = 13.0f;
    public float gravity = 20.0f;

    public int maxJumps = 2;
    int currentJumps;
    InputManager input;


    void Start()
    {
        anim = GetComponent<Animator>();
        input = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
		stateMachine = GetComponent<CombatController>();
        currentJumps = 0;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (controller.isGrounded)
        {
            
            currentJumps = 0;

            
            if (Input.GetAxis(input.leftAnalogX) > 0f)
            {
                transform.rotation = Quaternion.Euler(0f, Mathf.Abs(90f), 0f);
            }
            else if (Input.GetAxis(input.leftAnalogX) < 0f)
            {
                transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(90f), 0f);
            }
            
            Debug.Log(moveDirection);
            moveDirection = new Vector3(Input.GetAxis(input.leftAnalogX), 0, 0);
            controller.Move(moveDirection * Time.deltaTime * walkSpeed);

            if (moveDirection != Vector3.zero)
            {
               
                
                stateMachine.transition("move");
                //transform.forward = moveDirection;
            }
            else
            {
                stateMachine.transition("idle");
            }

            if (moveDirection.x.Equals(0))
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
            }
            else if (moveDirection.x.Equals(1) || moveDirection.x.Equals(-1))
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Walk", true);
                anim.SetBool("Run", false);
            }

            //moveDirection = transform.TransformDirection(moveDirection);
            //moveDirection *= walkSpeed;

            if ((Input.GetButtonDown(input.xButton) || Input.GetButtonDown(input.yButton)) && stateMachine.valid("jump"))
            {
				stateMachine.transition("jump");
                moveDirection.y = jumpHeight;
                currentJumps++;
				stateMachine.transition("idle");
            }
        }

        else if (!controller.isGrounded)
        {
            anim.SetBool("Walk", false);
            if (currentJumps == 0)
                currentJumps = 1;

            if (Input.GetButtonDown(input.xButton) || Input.GetButtonDown(input.yButton))
            {
                if (currentJumps < maxJumps)
                {
                    if (Input.GetAxis(input.leftAnalogX) < 0f)
                    {
                        transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(90f), 0f);
                    }
                    else if (Input.GetAxis(input.leftAnalogX) > 0f)
                    {
                        transform.rotation = Quaternion.Euler(0f, Mathf.Abs(90f), 0f);
                    }
                    moveDirection.y = jumpHeight;
                    currentJumps++;
                }



            }


            moveDirection.x = Input.GetAxis(input.leftAnalogX) * walkSpeed;

        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
