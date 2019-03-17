using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    //public ParticleSystem fire;
    private Animator anim;
	private CombatController stateMachine;
	private PlayerHealth health;
	private bool striking = false, struck = false, hitable = true;
	private string attackType;
	public float blockDuration = 0.75f, blockInvinsibility = 0.20f;
    InputManager input;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManager>();
        anim = GetComponent<Animator>();
		stateMachine = GetComponent<CombatController>();
		health = GetComponent<PlayerHealth>();
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
				//fire.Play();
				while (anim.GetCurrentAnimatorStateInfo(0).IsName(attackType))
				{
					if (struck)
					{
						stateMachine.transition("stumble");
						struck = false;
						health.TakeDamage(10);
						return;
					}
				}
				stateMachine.transition("idle");
			}
        }
		else if (Input.GetButtonDown(input.aButton) && stateMachine.valid("block"))
		{
			stateMachine.transition("block");
			anim.SetTrigger("block");
			float counter = 0f;
			while (counter <= blockDuration)
			{
				counter += Time.deltaTime;
				if (struck)
				{
					stateMachine.transition("stumble");
					struck = false;
					health.TakeDamage(10);
					return;
				}
				else if (counter <= blockInvinsibility)
				{
					hitable = false;
				}
				else
				{
					hitable = true;
				}
			}
			stateMachine.transition("idle");
		}
    }
	
	public bool getHit() 
	{
		if (hitable)
		{
			struck = true;
			return true;
		}
		return false;
	}
}
