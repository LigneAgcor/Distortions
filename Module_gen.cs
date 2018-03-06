using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Module_gen : MonoBehaviour {
	
	public AudioSource audSrc;
	private GameObject bgcam;
	private GameObject player;
	public bool Test = false;
	public module TestModule;
	public module[] m;
	public int mod_limit = 8;
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
		Debug.Log("addModule was called");
		if(run) {
			int rando = Random.Range(0, totalChance);
			int newDiff = 0;
			for (int i=1; i<=difficulty; i++){
				if (i*(i+1)/2 > rando)
					break;
				else newDiff = i;
			}
			GameObject newModule;
			if (mod_ctr % 6 == 5 && !GlobalVariables.tutorial){
				newModule = Instantiate(sz.gameObject);
				newModule.GetComponent<Transform> ().position = currentPos;
				SafeZone mod = newModule.GetComponent<SafeZone> ();
				currentPos = mod.getEnd ();
			}
			else if(GlobalVariables.tutorial)
				Debug.Log("Stop Instantiate");
			else{
				if(infinite)
				{
					int mod_type = Random.Range (0, modList[newDiff].Length);
					newModule = Instantiate (modList[newDiff][mod_type]);
					
					newModule.GetComponent<Transform> ().position = currentPos;
					module mod = newModule.GetComponent<module> ();
					if (current == null)
						mod.setup(this);
					else
						mod.setup(this, current);
					currentPos = mod.getEnd ();
					current = mod;
				}
				else
				{
					if (test) 
					{
						newModule = Instantiate (TestModule.gameObject);
						
						newModule.GetComponent<Transform> ().position = currentPos;
						module mod = newModule.GetComponent<module> ();
						if (current == null)
							mod.setup(this);
						else
							mod.setup(this, current);
						currentPos = mod.getEnd ();
						current = mod;
					}
					else if(mod_ctr < GlobalVariables.limit)
					{
						int mod_type = Random.Range (0, modList[newDiff].Length);
						newModule = Instantiate (modList[newDiff][mod_type]);
						
						newModule.GetComponent<Transform> ().position = currentPos;
						module mod = newModule.GetComponent<module> ();
						if (current == null)
							mod.setup(this);
						else
							mod.setup(this, current);
						currentPos = mod.getEnd ();
						current = mod;
					}
				}
			}
			mod_ctr++;
		}
	}
	
	void startLevel(int buffer){
		Debug.Log("startLevel was called");
		for (int i=0; i<buffer; i++){
			addModule();
		}
	}

	void setLevel(){
		Debug.Log("setLevel was called");
		while(mod_ctr < GlobalVariables.limit)
		{
			addModule();
		}
	}
	
	void tLevel(){
		try{
		while(mod_ctr < 6)
		{
			Debug.Log("tLevel Log: " + mod_ctr);
			int mod_type = Random.Range (0, m.Length);
			

			GameObject newModule = Instantiate (m[mod_ctr].gameObject);
			newModule.GetComponent<Transform> ().position = currentPos;
			module mod = newModule.GetComponent<module> ();
			mod.setup(this);
			currentPos = mod.getEnd ();
			mod_ctr++;
		}
		GameObject szModule = Instantiate (sz.gameObject);
		szModule.GetComponent<Transform> ().position = currentPos;
		module szmod = szModule.GetComponent<module> ();
		szmod.setup(this);
		currentPos = szmod.getEnd ();}
		catch(System.Exception aq){}
	}

	void Start ()
	{
		bgcam = GameObject.Find("BackgroundCam");
		player = GameObject.Find("Player");
		RenderSettings.ambientLight = GlobalVariables.acolor;
		audSrc.volume = GlobalVariables.volume;
		bgcam.GetComponent<Camera>().backgroundColor= new Color(0.5f, 0.5f, 0.5f, 1.0f);		
		
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
		if(GlobalVariables.tutorial) tLevel();
		else if (infinite) startLevel(3);
		else setLevel ();
	}
	
	void Update()
	{
		if(Input.GetButton("Cancel"))
		{
			SceneManager.UnloadSceneAsync(1);
			GlobalVariables.game = false;
			StopCoroutine(timer());
			player.GetComponent<controller>().stopBleed();
			Destroy(GameObject.Find("Player"));
			Destroy(bgcam);
			SceneManager.LoadScene(0);
		}
	}
}