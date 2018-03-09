using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour {
	
	public GameObject obj;
	public Vector3 position;
	public Quaternion rotation;
	
	void OnTriggerEnter(Collider c)
	{
		if(c.tag == "Player")
		{
			Instantiate(obj, position, rotation);
		}
	}
}
