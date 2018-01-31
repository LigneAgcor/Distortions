using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Teleport : MonoBehaviour {
	
	private Vector3 startpoint;
	private Vector3 resetpoint;
	public Transform Player;
	private controller player_control;
	private float defGrav;
	private float defJSpd;
	private float defSpd;
	private static Vector3 offset = new Vector3(0f,1.1f,0f);
	private List<Resettable> resettables = new List<Resettable>();
	
	void Start()
	{
		Player = GameObject.Find("Player").GetComponent<Transform>();
		startpoint = Player.GetComponent<Transform>().position;
		resetpoint = GetComponent<Transform>().position;
		player_control = Player.GetComponent<controller>();
		defGrav = player_control.defGravity;
		defJSpd = player_control.defJumpSpeed;
		defSpd = player_control.defSpeed;
		Debug.Log(startpoint);
	}
	void Update()
	{
		if(Player.transform.position.y < resetpoint.y)
		{
			Debug.Log(resettables.Count);
			Player.position = startpoint;
			Player.rotation = Quaternion.identity;
			player_control.defGravity = defGrav;
			player_control.defJumpSpeed = defJSpd;
			player_control.defSpeed = defSpd;
			foreach (Resettable r in resettables){
				r.reset();
			}
		}
	}
	
	public void reset(float newY, module starter){
		resetpoint.y = newY;
		startpoint = starter.GetComponent<Transform>().position + offset;
		resettables = starter.getResets();
	}
}
