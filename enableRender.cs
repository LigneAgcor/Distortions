using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enableRender : MonoBehaviour, Resettable {
	public GameObject[] go;
	
	void Start() {
		module tp = GetComponent<Transform>().root.GetComponent<module>();
		tp.AddToReset(this);
		for(int i = 0; i < go.Length; i++) go[i].SetActive(false);
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			for(int i = 0; i < go.Length; i++) go[i].SetActive(true);
		}
	}
	
	public void reset(){
		for(int i = 0; i < go.Length; i++) go[i].SetActive(false);
	}
}