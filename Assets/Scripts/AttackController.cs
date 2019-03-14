using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public ParticleSystem fire;
    private Animator anim;
	private CombatController stateMachine;
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
        if (Input.GetAxis(input.leftAnalogY) > 0 && Input.GetButtonDown(input.bButton) && stateMachine.valid("strike"))
        {
			stateMachine.transition("strike");
            anim.SetTrigger("DownSmash");
            fire.Play();
        }

        else if (Input.GetAxis(input.leftAnalogY) < 0 && Input.GetButtonDown(input.bButton) && stateMachine.valid("strike"))
        {
			stateMachine.transition("strike");
            anim.SetTrigger("UpSmash");
            fire.Play();
        }
    }
}
