using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Bar : MonoBehaviour {
	
	public GameObject player;
	public GameObject UI;
	public Slider slid;
	public RectTransform Bar;
	private controller p_script;
	// Use this for initialization
	void Start () {
		UI.SetActive(false);
		p_script = player.GetComponent<controller>();
	}
	
	// Update is called once per frame
	void Update () {
		slid.value = p_script.life;
		Bar.sizeDelta = new Vector2(p_script.life, Bar.sizeDelta.y);
		if(GlobalVariables.game)
			UI.SetActive(true);
	}
}
