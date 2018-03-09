using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPlatformVis : MonoBehaviour {
	
	public GameObject[] platformsVisible;
	public GameObject[] platformsInvisible;
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			for(int i = 0; i < platformsVisible.Length; i++)
				platformsVisible[i].SetActive(true);
			for(int j = 0; j < platformsInvisible.Length; j++)
				platformsInvisible[j].SetActive(false);
		}
	}
}
