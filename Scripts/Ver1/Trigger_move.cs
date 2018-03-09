using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_move : MonoBehaviour {
	
	public MovingPlatform mv;
	void OnTriggerEnter(Collider body)
	{
		if(body.tag == "Player")
		{
			mv.moving = true;
		}
	}
}
