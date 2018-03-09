using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallrunner : MonoBehaviour {

	private bool wallrunning = false;
	public float speedMultiplier = 0f;
	public bool ready = false;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Solid"){
			ready = true;
			speedMultiplier = 1.8f;
			StartCoroutine (startCheck());
		}
	}

	public bool getState(){
		return wallrunning;
	}

	public float getSpeedMult(){
		return speedMultiplier;
	}

	IEnumerator startCheck(){
		while (true) {
			if (Input.GetButton ("Jump") && !wallrunning) {
				ready = false;
				wallrunning = true;
				yield return timedStop ();
				break;
			}
			yield return new WaitForEndOfFrame ();
		}
	}

	IEnumerator timedStop(){
		yield return new WaitForSeconds (0.8f);
		ready = true;
	}


	void OnTriggerExit(Collider other){
		if (other.tag == "Solid") {
			wallrunning = false;
			ready = false;
			StopAllCoroutines ();
		}
	}

	public void reset(){
		wallrunning = false;
		ready = false;
		StopAllCoroutines ();
	}
}
