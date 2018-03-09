using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour {

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
	
	public void OnTriggerExit(Collider o){
		if (o.CompareTag("Player")){
			controller c = o.gameObject.GetComponent<controller>();
			c.moveTest = false;
			Destroy(this);
		}
	}
	
	public void OnTriggerEnter(Collider o){
		if (o.CompareTag("Player")){
			controller c = o.gameObject.GetComponent<controller>();
			c.moveTest = true;
			
		}
	}
}