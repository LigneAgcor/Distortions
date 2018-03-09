using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Spring : MonoBehaviour {
	
	public float up;
	public float forward;
	void OnTriggerEnter(Collider body)
	{
		try
		{
			if (body.tag == "Player") {
				body.gameObject.GetComponent<controller> ().controlledMove (forward, up);
			}
		}
		catch(NullReferenceException ae){}
	}
	
}
