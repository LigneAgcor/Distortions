using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Reset_Parameters : MonoBehaviour {
	
	public GameObject parChngr;
	private float defGrav;
	private float defJSpd;
	private float defSpd;
	private bool defMt;
	
	void OnTriggerEnter(Collider body)
	{
		Parameter_Changer ParScript = parChngr.gameObject.GetComponent<Parameter_Changer>();
		defGrav = ParScript.Grav;
		defJSpd = ParScript.JS;
		defSpd = ParScript.Spd;
		defMt = ParScript.MT;
		if(body.tag == "Player")
		{
			try{
				controller body_control = body.gameObject.GetComponent<controller>();
				body_control.defGravity = defGrav;
				body_control.defJumpSpeed = defJSpd;
				body_control.defSpeed = defSpd;
				body_control.moveTest = defMt;
			}
			catch(NullReferenceException ad){}
		}
	}
}
