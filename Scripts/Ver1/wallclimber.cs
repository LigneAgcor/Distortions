using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallclimber : MonoBehaviour {

	public float speed = 0f;
	public float duration = 0.9f;
	public bool climbing = false;
	public bool ready = false;
	public bool falling = false;
	private Collider o;

	void OnTriggerEnter(Collider other){
		if(other.tag != "Player")
			Debug.Log("Hit");
		else
			Debug.Log("Player");
		if (other.tag == "Solid") {
			Debug.Log("Solid");
			//o = other;
			ready = true;
			speed = 5f;
			StartCoroutine (startCheck());
		}
	}

	private bool checking = true;
	public IEnumerator startCheck(){
		checking = true;
		falling = false;
		while (checking) {
			if (climbing && !Input.GetButton ("Jump")) {
				climbing = false;
				falling = true;
				break;
			}
			else if (!climbing && Input.GetButton ("Jump")) {
				climbing = true;
				StartCoroutine (timedStop ());
			}

			yield return new WaitForEndOfFrame ();
		}
	}
		
	IEnumerator timedStop(){
		yield return new WaitForSeconds (duration);
		Debug.Log ("timeout");
		checking = false;
		StopCoroutine (startCheck ());
		climbing = false;
		falling = true;
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Solid") {
			reset ();
		}
	}

	public void reset(){
		climbing = false;
		falling = false;
		ready = false;
		StopAllCoroutines ();
	}
}
