using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class disableRender : MonoBehaviour {
	public GameObject[] go;
	
	void Start() {
		for(int i = 0; i < go.Length; i++) go[i].SetActive(true);
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			for(int i = 0; i < go.Length; i++) go[i].SetActive(false);
		}
	}
}