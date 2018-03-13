﻿using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
	{
		Debug.Log ("Level Load request for:" + name);
		Application.LoadLevel (name);
	}
	public void QuitRequest()
	{
		Debug.Log ("I want to quit");
		Application.Quit ();
	}
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	public void BreakBrick(){
		if(Brick.breakableCount<=0){
			LoadNextLevel();
		}
	}
}