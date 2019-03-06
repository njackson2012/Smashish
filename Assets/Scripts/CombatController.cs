using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
	bool striking = false, moving = false, blocking = false, stumbling = false, inAir = false;
	
    void Start()
	{
		
	}

	void Update()
	{
		
	}
	
	void transition(string move)
	{
		if (move == "strike"){
			if (! inAir){
				moving = false;
			}
			striking = true;
		}
		else if (move == "move"){
			moving = true;
		}
		else if (move == "block"){
			moving = false;
			blocking = true;
		}
		else if (move == "jump"){
			inAir = true;
		}
		else if (move == "stumble"){
			moving = false;
			striking = false;
			stumbling = true;
		}
		else if (move == "idle" && ! stumbling){
			striking = false;
			moving = false;
			blocking = false;
			inAir = false;
		}
	}
	bool valid(string move){
		if (move == "strike"){
			return(! stumbling && ! striking && ! blocking);
		}
		else if (move == "move"){
			return(! stumbling && (! moving || inAir));
		}
		else if (move == "block"){
			return(! striking && ! inAir);
		}
		else if (move == "jump"){
			return(! striking && ! stumbling && ! blocking);
		}
		else if (move == "stumble"){
			return(! blocking);
		}
	}
}
