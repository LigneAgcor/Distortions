using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour {
	
	public void setDiff(int i){
		if(i > 0)
		{
			GlobalVariables.difficulty = i;
			GlobalVariables.tutorial = false;
		}
		else
		{
			GlobalVariables.difficulty = 1;
			GlobalVariables.tutorial = true;
		}
	}
    public void TaskOnClick(int sceneIndex)
    {
		GlobalVariables.inenable = true;
		SceneManager.UnloadSceneAsync(0);
		SceneManager.LoadScene(sceneIndex);
		GlobalVariables.game = true;
    }
}
