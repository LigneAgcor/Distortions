using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour {

	void OnTriggerEnter(Collider a)
	{
		if(a.tag == "Solid")
			Debug.Log("Wooooooooooow");
	}
}
