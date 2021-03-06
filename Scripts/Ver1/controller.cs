using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controller : MonoBehaviour {
	
	public wallclimber front;
	public wallrunner[] sides;
	public bool moveTest = false;
	public float defSpeed = 10.0F;
	public float defJumpSpeed = 8.0F;
	public float defGravity = 15.0F;
	public static Vector3 moveDirection = Vector3.zero;
	public static CharacterController charController;
	private float speed;
	private float jumpSpeed;
	private float gravity;
	public float life = 90f;
	private float zCurrent;
	private Transform t;
	
	private bool stopped = false;

	void Start(){
		DontDestroyOnLoad(this);
		t = GetComponent<Transform> ();
		zCurrent = t.position.z;
		charController = GetComponent<CharacterController> ();
		speed = defSpeed;
		jumpSpeed = defJumpSpeed;
		gravity = defGravity;
		if(!moveTest)
			StartCoroutine (bleed());
	}
	
	public void Set()
	{
		defGravity = 25;
		defSpeed = 10;
		defJumpSpeed = 10;
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "projectile") {
			//player takes damage
		}
	}
	void damage(float amount){
		life -= amount;
		life = Mathf.Clamp(life, 0f, 90f);
	}
	
	public void stopTrigger()
	{
		stopped = !stopped;
	}

	IEnumerator bleed(){
		while (true) {
			float newZ = t.position.z;
			if (newZ <= zCurrent) {
				damage (9f);
				if (life <= 0) {
					break;
				}
				zCurrent = newZ;
				yield return new WaitForSeconds (0.5f);
			} else if (life < 100) {
				damage (-9f);
				zCurrent = newZ;
				yield return new WaitForSeconds (0.1f);
			}
			else {
				zCurrent = newZ;
				yield return new WaitForEndOfFrame ();
			}
		}
	}

	public void gameOver(){
		t.SetPositionAndRotation (new Vector3(0f,1f,0f), Quaternion.identity);
		life = 100f;
		StopCoroutine (bleed ());
		StartCoroutine (bleed ());
	}

	public void controlledMove(float forward, float upward){
		speed = forward;
		moveDirection.y = upward;
		charController.Move (moveDirection * Time.deltaTime);
	}

	void Update() {
		
			if(stopped)
				StopCoroutine(bleed());
			
			if (life <= 0) {
			gameOver ();
			}
			gravity = defGravity;
			jumpSpeed = defJumpSpeed;
			

			float y = moveDirection.y;
			foreach (wallrunner w in sides) {
				if (w.ready || w.getState ()) {
					if (charController.isGrounded)
						w.reset ();
					if (Input.GetButton ("Jump") && !w.ready && w.getState ())
						speed = defSpeed * w.getSpeedMult ();
					speed = defSpeed * 1.8f;
					if (Mathf.Abs (y) < 1.5f) {
						gravity = 3f;
					}
					break;
				}
			}
			
				moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, (moveTest ? Input.GetAxis("Vertical") : 1));
				moveDirection = transform.TransformDirection(moveDirection);
				moveDirection.z *= speed;
				moveDirection.x *= defSpeed;
				moveDirection.y = y;
				
				if (charController.isGrounded) {
				speed = defSpeed;
				moveDirection.y = 0;
				if (Input.GetButton ("Jump")) {
					moveDirection.y = jumpSpeed;
				}

			}
			moveDirection.y -= gravity * Time.deltaTime;
			if (front.ready) {
				if (Input.GetButton ("Jump") && front.climbing && !front.falling && moveDirection.y >= 0f) {
					moveDirection.y = front.speed;
					//Debug.Log ("climbing");
				}
				if (charController.isGrounded && front.falling) {
					front.StartCoroutine (front.startCheck ());
					Debug.Log ("restart climb");
				}
					
			}
		
		// Debug.Log("Player: " + moveDirection.z);
		charController.Move(moveDirection * Time.deltaTime);
	}

}