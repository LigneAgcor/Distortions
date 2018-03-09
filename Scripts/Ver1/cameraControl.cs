using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

	public float xSensitivity = 1.0f;
	public float ySensitivity = 1.5f;
	public int maxX = 30;
	public int maxY = 75;
	public bool inverse = false;
	private Transform t;
	private Vector2 current;

	void Start(){
		t = gameObject.GetComponent<Transform> ();
		current = Vector2.zero;
	}

	void Update(){
		if (inverse) current.x = Mathf.Clamp (current.x + Input.GetAxis ("Mouse X") * xSensitivity, 180-maxX, 180+maxX);
		else current.x = Mathf.Clamp (current.x + Input.GetAxis ("Mouse X") * xSensitivity, -maxX, maxX);
		
		current.y = Mathf.Clamp (current.y - Input.GetAxis ("Mouse Y") * ySensitivity, -maxY, maxY);
		t.rotation = Quaternion.Euler (current.y, current.x, 0);
	}
}
