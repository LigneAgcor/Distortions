using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module_gen : MonoBehaviour {
	
	public bool Test = false;
	public module TestModule;
	public module[] m;
	public int mod_limit = 6;
	public int difficulty = 1;
	public bool infinite = false;
	private int mod_ctr = 0;
	public Test_Teleport resetter;
	private module current;
	private bool run = true;
	private int totalChance = 0;
	public SafeZone sz;
	Vector3 currentPos = Vector3.zero;
	[HideInInspector]
	public Sprite[] gSprite, bSprite;
	[HideInInspector]
	public GameObject[][] modList;
	
	public IEnumerator timer() {
		yield return new WaitForSeconds(270f);
		run = false;
	}
	
	public void addModule(bool test = false){
		if(run) {
			int rando = Random.Range(0, totalChance);
			int newDiff = 0;
			for (int i=1; i<=difficulty; i++){
				if (i*(i+1)/2 > rando)
					break;
				else newDiff = i;
			}
			GameObject newModule; 
			if (mod_ctr % 6 == 5){
				newModule = Instantiate(sz.gameObject);
				newModule.GetComponent<Transform> ().position = currentPos;
				SafeZone mod = newModule.GetComponent<SafeZone> ();
				currentPos = mod.getEnd ();
			}
			else{
				if (test) 
					newModule = Instantiate (TestModule.gameObject);
				else {
					int mod_type = Random.Range (0, modList[newDiff].Length);
					newModule = Instantiate (modList[newDiff][mod_type]);
				}
				newModule.GetComponent<Transform> ().position = currentPos;
				module mod = newModule.GetComponent<module> ();
				if (current == null)
					mod.setup(this);
				else
					mod.setup(this, current);
				currentPos = mod.getEnd ();
				current = mod;
			}
			mod_ctr++;
		}
	}
	
	void startLevel(int buffer){
		for (int i=0; i<buffer; i++){
			addModule();
		}
	}

	void setLevel(){
		while(mod_ctr < mod_limit)
		{
			int mod_type = Random.Range (0, m.Length);
			

			GameObject newModule = Instantiate (m [mod_type].gameObject);
			newModule.GetComponent<Transform> ().position = currentPos;
			module mod = newModule.GetComponent<module> ();
			mod.setup(this);
			currentPos = mod.getEnd ();
			mod_ctr++;
		}
	}

	void Start ()
	{
		StartCoroutine(timer());
		difficulty = GlobalVariables.difficulty;
		totalChance = difficulty*(difficulty+1)/2;
		modList = new GameObject[difficulty][];
		for (int i=0; i < difficulty; i++){
			modList[i] = Resources.LoadAll<GameObject>("Modules/" + (i+1).ToString());
			Debug.Log(difficulty + ". Hurray! " + modList[i].Length);
		}
		
		int bad = Random.Range (1, difficulty+1);
		if (difficulty > 4) bad = Mathf.Max(bad, 3);
		int good = 7-difficulty + bad;
		gSprite = Resources.LoadAll<Sprite>("Gabors/" + good.ToString());
		bSprite = Resources.LoadAll<Sprite>("Gabors/" + bad.ToString());
		if (Test){
			addModule(true);
			return;
		}
		if (infinite) startLevel(3);
		else setLevel ();
	}
}
