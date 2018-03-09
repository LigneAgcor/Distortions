using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Parameter_Changer : MonoBehaviour {
	
	controller player_control;
	private float Grav;
	private float JS;
	private float Spd;
	private bool MT;
	public enum Choices
	{
		Gravity,
		JumpSpeed,
		Speed,
		Manual_Movement
	};
	
	public Choices[] modified;
	public float[] modifier;
	
	public float[] getStats()
	{
		float[] temp = {Grav, JS, Spd};
		return temp;
	}

	public bool getMT()
	{
		return MT;
	}

	void OnTriggerEnter(Collider body)
	{
		
		if(body.tag == "Player")
		{
			try{
				
			player_control = body.gameObject.GetComponent<controller>();
				Grav = player_control.defGravity;
				JS = player_control.defJumpSpeed;
				Spd = player_control.defSpeed;
				MT = player_control.moveTest;
				for(int c = 0; c < modified.Length; c++)
				{
					if(modified[c] == Choices.Gravity)
						player_control.defGravity = modifier[c];
					else if(modified[c] == Choices.JumpSpeed)
						player_control.defJumpSpeed = modifier[c];
					else if(modified[c] == Choices.Speed)
						player_control.defSpeed = modifier[c];
					else if(modified[c] == Choices.Manual_Movement)
						player_control.moveTest = !player_control.moveTest;
					else
						Debug.Log("Welp");
				}
			}
			catch(NullReferenceException dc){}
		}
	}
}
