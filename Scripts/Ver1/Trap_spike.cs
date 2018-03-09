using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_spike : MonoBehaviour {

	public GameObject spikes;
	private bool activated = false;
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && !activated)
		{
			spikes.transform.Translate(0,0.7f,0);
			activated = true;
		}
	}
}
