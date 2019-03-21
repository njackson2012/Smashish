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

    public AudioSource sound;

    public ParticleSystem fire_hand;
    public ParticleSystem fire_left;
    public ParticleSystem fire_right;

    InputManager input;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
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
            sound.Play();
            striking = false;
            if (Input.GetAxis(input.leftAnalogY) > 0)
            {
                striking = true;
                attackType = "DownSmash";
                fire_right.Play();
                fire_left.Play();
                var sideSmashClip = Resources.Load<AudioClip>("punch");

            }
            else if (Input.GetAxis(input.leftAnalogY) < 0)
            {
                striking = true;
                attackType = "UpSmash";
                fire_left.Play();
            }
            else
            {
                striking = true;
                attackType = "SideSmash";
                fire_left.Play();
            }

            if (striking)
            {
                stateMachine.transition("strike");
                anim.SetTrigger(attackType);
                /*
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
                */
                stateMachine.transition("idle");
            }
        }
        else if ((Input.GetButtonDown(input.lbButton) || Input.GetButtonDown(input.rbButton)) && stateMachine.valid("block"))
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

    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {

        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;

        return newAudio;

    }
}
