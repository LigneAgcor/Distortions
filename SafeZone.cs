using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeZone : MonoBehaviour {
	
	public GameObject message_canvas_start;
	public GameObject message_canvas_end;
	private GameObject message_canvas;
	private bool triggered = false;
	private bool end = false;
	private controller player;
	private GameObject playerObj;
	
	public Vector3 getEnd(){
		Vector3 lastPos = Vector3.zero;
		Renderer renderer = GetComponent<Renderer> ();
		float zEnd = renderer.bounds.max.z;
		Renderer[] children = GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in children) {
			Bounds b = r.bounds;
			
			float rZ = b.max.z;
			Transform t = r.GetComponent<Transform>();
			if (rZ > zEnd){
				zEnd = rZ;
				Vector3 pos = t.position;
				lastPos.x = pos.x;
				lastPos.y = pos.y;
			}
		}
		lastPos.y += 0.5f;
		lastPos.z = zEnd;
		return lastPos;
	}
	
	void Update()
	{
		if(Input.GetButton("Jump") && triggered)
		{
			StopCoroutine(GlobalVariables.wait(1.0f));
			message_canvas.SetActive(false);
			StartCoroutine(GlobalVariables.wait(0.05f));
			player.stopTrigger();
			Destroy(message_canvas);
			triggered = false;
			if(end)
			{
				StopCoroutine(GlobalVariables.wait(0.05f));
				SceneManager.UnloadSceneAsync(1);
				GlobalVariables.game = false;
				GlobalVariables.tutorial = false;
				Destroy(playerObj);
				SceneManager.LoadScene(0);
			}
		}
	}
	
	public void OnTriggerExit(Collider o){
		if (o.CompareTag("Player")){
			controller c = o.gameObject.GetComponent<controller>();
			if(GlobalVariables.tutorial){
				//Show message and go back to main menu
				message_canvas = message_canvas_end;
				message_canvas.SetActive(true);
				StartCoroutine(GlobalVariables.wait(1.0f));
				c.stopTrigger();
				triggered = true;
				end = true;
			}
			else{
				c.moveTest = false;
				c.startBleed();
				Destroy(this);
			}
		}
	}
	
	public void OnTriggerEnter(Collider o){
		if (o.CompareTag("Player")){
			playerObj = o.gameObject;
			player = playerObj.GetComponent<controller>();
			controller c = o.gameObject.GetComponent<controller>();
			c.moveTest = true;
			c.stopBleed();
			if(GlobalVariables.tutorial){
				StartCoroutine(GlobalVariables.wait(1.0f));
				message_canvas = message_canvas_start;
				message_canvas.SetActive(true);
				c.stopTrigger();
				triggered = true;
			}
			
		}
	}
}