using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Life_UI : MonoBehaviour {
	
	controller Player;
	public Image[] Lives;
	float life;
	float PerLife;
	Vector2 orig;
	
	// Use this for initialization
	void Start () {
		Player = GameObject.Find("Player").GetComponent<controller>();
		// orig = new Vector2(15f,35f);
		// foreach (Image i in Lives){
			// i.GetComponent<RectTransform>().sizeDelta = new Vector2(15f,0f);
		// }
	}
	
	
	// Update is called once per frame
	void Update () {
		// life = 15f;
		// int fulls = (int) (life/30f);
		// Debug.Log(orig);
		// Vector2 newSize = orig;
		
		// for (int i=0; i<2; i++){
			// if (i < fulls){
				// Lives[i].GetComponent<RectTransform>().sizeDelta = orig;
			// }
			// else {
				// newSize.y = 35f * (life - (i*30f))/30f;
				// Debug.Log(newSize.y);
				// Lives[i].GetComponent<RectTransform>().sizeDelta.y = newSize;
				// break;
			// }
		// }
		
		
		// newSize = Lives[1].GetComponent<RectTransform>().sizeDelta;
		// newSize.y = 35f * Mathf.Clamp( Mathf.InverseLerp(30, 60, life), 0, 1);
		// Lives[1].GetComponent<RectTransform>().sizeDelta = newSize;
		
		// newSize = Lives[2].GetComponent<RectTransform>().sizeDelta;
		// newSize.y = 35f * Mathf.Clamp( Mathf.InverseLerp(60, 90, life), 0, 1);
		// Lives[2].GetComponent<RectTransform>().sizeDelta = newSize;
		// PerLife = life/90;
		// if(life <= 30)
		// {
			// Lives[0].rectTransform.Height = Orig_Height * PerLife;
		// }
		// if(life <= 60)
		// {
			// Lives[1].rectTransform.Height = Orig_Height * PerLife;
		// }
		// if(life <= 90)
		// {
			// Lives[2].rectTransform.Height = Orig_Height * PerLife;
		// }
		// for(int i = 0; i<2; i++)
		// {
			// if(i <= life/3)
			// {
				
			// }
		// }
	}
}
