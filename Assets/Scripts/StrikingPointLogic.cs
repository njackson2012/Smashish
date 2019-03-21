using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikingPointLogic : MonoBehaviour
{
	public GameObject mySelf, myEnemy;
    PlayerHealth health;
    CombatController state;

	void Start()
	{
        state = mySelf.GetComponent<CombatController>();
        health = myEnemy.GetComponent<PlayerHealth>();
        GetComponent<Collider>().enabled = false;
    }
	
	void Update()
	{
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.name == myEnemy.name)
		{
            if (state.striking)
            {
                Debug.Log("hit");
                string line = mySelf.name + " hit " + myEnemy.name + " with " + transform.parent.name + "\n";
                System.IO.File.AppendAllText(@".\WriteLines.txt", line);
                health.TakeDamage(10);
                GetComponent<Collider>().enabled = false;

            }
            if (! other.GetComponent<AttackController>().getHit())
			{
				mySelf.GetComponent<AttackController>().getHit();
				mySelf.GetComponent<CombatController>().transition("stumble");
			}
		}
	}
}