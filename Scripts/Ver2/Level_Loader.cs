using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Level_Loader : MonoBehaviour {
	
	public InputField modLimit;
	public AudioSource audSrc;
	public Slider slide;
	public Material mat;
	public module backmod;
	private controller p_con;
	
	public void setDiff(int i){
		if(i > 6)
		{
			GlobalVariables.difficulty = i;
			GlobalVariables.tutorial = false;
			GlobalVariables.experiment = false;
		}
		else if(i > 0)
		{
			GlobalVariables.difficulty = i;
			GlobalVariables.tutorial = false;
			GlobalVariables.experiment = false;
		}
		else if (i == 0)
		{
			GlobalVariables.difficulty = 1;
			GlobalVariables.tutorial = true;
			GlobalVariables.experiment = false;
		}
		else
		{
			GlobalVariables.difficulty = 1;
			GlobalVariables.experiment = true;
			GlobalVariables.tutorial = false;
		}
	}
    public void TaskOnClick(int sceneIndex)
    {
		if(GlobalVariables.experiment)
		{
			GlobalVariables.mod_mat = mat;
			GlobalVariables.bgmodule = backmod;
		}
		GlobalVariables.volume = audSrc.volume;
		GlobalVariables.inenable = true;
		GlobalVariables.game = true;
		Cursor.visible = false;
		p_con.stopBleed();
		p_con.startBleed();
		SceneManager.UnloadSceneAsync(0);
		SceneManager.LoadScene(sceneIndex);
    }
	
	void Start()
	{
		try{
			p_con = GameObject.Find("Player").GetComponent<controller>();
			audSrc.volume = GlobalVariables.volume;		
			slide.value = GlobalVariables.volume;
			modLimit.onEndEdit.AddListener(PassValue);}
		catch(Exception ae){}
	}
	
	private void PassValue(string modlim)
	{
		GlobalVariables.limit = int.Parse(modlim);
	}
}
