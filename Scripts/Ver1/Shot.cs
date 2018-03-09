using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {
	
	public float speed = 6.0f;
	public int direction = 1;
	// Use this for initialization
	void Start () {
		if(direction == 1)
			this.GetComponent<Rigidbody>().velocity = -transform.forward * speed;
		if(direction == 2)
			this.GetComponent<Rigidbody>().velocity = transform.forward * speed;
		if(direction == 3)
			this.GetComponent<Rigidbody>().velocity = transform.up * speed;
		if(direction == 4)
			this.GetComponent<Rigidbody>().velocity = -transform.up * speed;
	}
}
