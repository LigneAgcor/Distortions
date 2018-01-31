using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Parameter_Changer : MonoBehaviour {
	
	controller player_control;
	public float Grav;
	public float JS;
	public float Spd;
	public bool MT;
	public enum Choices
	{
		Gravity,
		JumpSpeed,
		Speed,
		Manual_Movement
	};
	
	public Choices modified;
	public float modifier;
	
	void OnTriggerEnter(Collider body)
	{
		Debug.Log(modified == Choices.Gravity);
		if(body.tag == "Player")
		{
			try{
				
			player_control = body.gameObject.GetComponent<controller>();
			
			if(modified == Choices.Gravity)
				player_control.defGravity = modifier;
			else if(modified == Choices.JumpSpeed)
				player_control.defJumpSpeed = modifier;
			else if(modified == Choices.Speed)
				player_control.defSpeed = modifier;
			else if(modified == Choices.Manual_Movement)
				player_control.moveTest = !player_control.moveTest;
			else
				Debug.Log("Welp");
			}
			catch(NullReferenceException dc){}
		}
	}
}
