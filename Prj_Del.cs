using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prj_Del : MonoBehaviour {
	
	void OnTriggerExit(Collider shot)
	{
		Rigidbody rbody = shot.attachedRigidbody;
		try
		{
			if(rbody.tag == "projectile")
			{
				Destroy(rbody.gameObject);
			}
		}
		catch(NullReferenceException a){}
	}
}
