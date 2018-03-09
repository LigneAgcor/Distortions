using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFade : MonoBehaviour, Resettable {

	public bool good = false;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		module tp = GetComponent<Transform>().root.GetComponent<module>();
		tp.AddToReset(this);
	}
	
	public void setSprite(Sprite[] g, Sprite[] b){
		SpriteRenderer spr = GetComponent<SpriteRenderer>();
		int spriteType = Random.Range (0, 4);
		if (good) spr.sprite = g[spriteType];
		else spr.sprite = b[spriteType];
	}
	
	public void reset() {
		anim.SetBool("Active", false);
	}
	
	void OnTriggerEnter(Collider o){
		if (o.tag == "Player")
			Debug.Log(this);
			anim.SetBool("Active", true);
	}
}
