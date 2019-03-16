using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikingPointLogic : MonoBehaviour
{
	public GameObject mySelf, myEnemy;
	void Start()
	{
	}
	
	void Update()
	{
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.name == myEnemy.name)
		{
			if (! other.GetComponent<AttackController>().getHit())
			{
				mySelf.GetComponent<AttackController>().getHit();
				mySelf.GetComponent<CombatController>().transition("stumble");
			}
		}
	}
}