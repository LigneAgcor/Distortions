using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proj_gen : MonoBehaviour {
	
	public GameObject[] prj;
	public Transform gen_placement;
	public float interval;
	private float limiter;
	
	// Update is called once per frame
	void Update () {
			int shot_type = Random.Range(0,prj.Length);
			if(Time.time > limiter)
			{
				limiter = Time.time + interval;
				GameObject projectile = prj[shot_type];
				projectile.GetComponent<Shot>().origin = this;
				Instantiate(projectile, gen_placement.position, gen_placement.rotation);
			}
	}
}
