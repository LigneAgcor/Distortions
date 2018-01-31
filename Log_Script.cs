using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Script : MonoBehaviour {
	
	public GameObject log;
	//private Vector3 Log_position = Log_transform.position;
	void Start()
	{
		Destroy(log, 10);
	}
}
