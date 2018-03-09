using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physics : MonoBehaviour {

	public Transform Obj_transform;
	private Vector3 Target;
	private float smoothFactor = 2;
	private bool sprung = false;
	
	public void Sprung(float forward, float up)
	{
		Obj_transform.position += Vector3.up * up;
		Target = new Vector3(Obj_transform.position.x, Obj_transform.position.y + up, Obj_transform.position.z + forward);
		sprung = true;
	}
	
	void Update()
	{
		if(sprung)
		{
			Obj_transform.position = Vector3.Lerp(Obj_transform.position, Target, Time.deltaTime * smoothFactor);
			
			if(Obj_transform.position == Target)
				sprung = false;
		}
	}
}
