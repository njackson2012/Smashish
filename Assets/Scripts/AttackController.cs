using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public ParticleSystem fire;
    private Animator anim;
	private CombatController stateMachine;
	private bool striking = false, struck = false;
	private string attackType;
	public float blockDuration = 0.1f;
    InputManager input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManager>();
        anim = GetComponent<Animator>();
		stateMachine = GetComponent<CombatController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(input.bButton) && stateMachine.valid("strike"))
        {
			striking = false;
			if (Input.GetAxis(input.leftAnalogY) > 0)
			{
				striking = true;
				attackType = "DownSmash";
			}
			else if (Input.GetAxis(input.leftAnalogY) < 0)
			{
				striking = true;
				attackType = "UpSmash";
			}
			
			if (striking)
			{
				stateMachine.transition("strike");
				anim.SetTrigger(attackType);
				fire.Play();
				while (anim.IsPlaying(attackType))
				{
					if (struck)
					{
						stateMachine.transition("stumble");
						struck = false;
						return;
					}
				}
				stateMachine.transition("idle");
			}
        }
    }
}
