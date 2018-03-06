using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class module : MonoBehaviour {
	
	public int difficulty;
	private float lowest;
	private Module_gen gen;
	private Test_Teleport tp;
	private module deleter;
	private List<Resettable> resets = new List<Resettable>();
	
	public List<Resettable> getResets(){
		return resets;
	}
	
	public float getLow(){ return lowest;}
	public Module_gen getGen(){ return gen;}
	public Test_Teleport getTp(){ return tp;}
	public module getDel(){ return deleter;}
	
	public void AddToReset(Resettable r){
		resets.Add(r);
		Debug.Log("Added " + r + " to List: " + resets.Count);
	}

	public void setup(Module_gen mg, module del){gen = mg;
		tp = GameObject.Find("Reset").GetComponent<Test_Teleport>();
		foreach (StartFade sf in GetComponentsInChildren<StartFade>()){
			sf.setSprite(gen.gSprite, gen.bSprite);
		}
		deleter = del;
	}
	
	public void setup(Module_gen mg){
		Debug.Log("Establishing Module Connections.");
		
		gen = mg;
		tp = GameObject.Find("Reset").GetComponent<Test_Teleport>();
		foreach (StartFade sf in GetComponentsInChildren<StartFade>()){
			sf.setSprite(gen.gSprite, gen.bSprite);
		}
	}
	
	void Start(){
		lowest = GetComponent<Transform>().position.y -0.5f;
	}
	
	public Vector3 getEnd(){
		Vector3 lastPos = Vector3.zero;
		Renderer renderer = GetComponent<Renderer> ();
		float zEnd = renderer.bounds.max.z;
		Renderer[] children = GetComponentsInChildren<Renderer> ();
		foreach (Renderer r in children) {
			Bounds b = r.bounds;
			
			float rZ = b.max.z;
			Transform t = r.GetComponent<Transform>();
			if (rZ > zEnd){
				zEnd = rZ;
				Vector3 pos = t.position;
				lastPos.x = pos.x;
				lastPos.y = pos.y;
			}
			if (lowest > b.min.y)
				lowest = b.min.y;
		}
		lastPos.y += 0.5f;
		lastPos.z = zEnd;
		return lastPos;
	}
	
	public void OnTriggerExit(Collider other){
		if (other.tag == "Player"){
			gen.addModule();
			tp.reset(lowest - 25f, this);
			GetComponent<Collider>().enabled = false;
			if (deleter != null) Destroy(deleter.gameObject);
		}
	}
}
