using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Script : MonoBehaviour {
	
	public GameObject message_canvas;
	private controller player;
	private bool triggered = false;
	private bool waiting = true;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter(Collider body)
	{
		try
		{
			if(!triggered && GlobalVariables.tutorial && waiting)
			{
				player = body.GetComponent<controller>();
				message_canvas.SetActive(true);
				player.stopTrigger();
				triggered = true;
				StartCoroutine(GlobalVariables.wait(1f));
			}
			
		}
		catch(System.NullReferenceException ae)
		{
			Debug.Log("Caught");
		}
	}
	
	void Update()
	{
		
		if(Input.GetButton("Jump") && triggered && GlobalVariables.inenable)
		{
			message_canvas.SetActive(false);
			StopCoroutine(GlobalVariables.wait(1f));
			StartCoroutine(GlobalVariables.wait(0.15f));
			player.stopTrigger();
			triggered = false;
			waiting = false;
		}
		if(GlobalVariables.inenable && !waiting)
		{
			Debug.Log("Destroying Object");
			Destroy(message_canvas);
			Destroy(this);
		}
	}
}
