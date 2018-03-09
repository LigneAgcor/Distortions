using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour {
	
	public void setDiff(int i){
		GlobalVariables.difficulty = i;
	}
    public void TaskOnClick(int sceneIndex)
    {
		SceneManager.LoadScene(sceneIndex);
    }
}
