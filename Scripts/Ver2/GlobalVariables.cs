﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables{
	
	public static int difficulty = 1;
	public static Color acolor = new Color(0.7f,0.7f,0.7f,1.0f);
	public static Color bgcolor = new Color(0.7f,0.7f,0.7f,1.0f);
	public static float volume = 1f;
	public static int limit = 9;
	public static bool infinity = false;
	public static bool tutorial = false;
	public static bool experiment = false;
	public static bool game = false;
	public static bool inenable = true;
	public static Material mod_mat;
	public static module bgmodule;
	public static IEnumerator wait(float f)
	{
		inenable = false;
		Debug.Log("FIRST: " + inenable);
		yield return new WaitForSeconds(f);
		inenable = true;
		Debug.Log("LAST: " + inenable);
	}
}
