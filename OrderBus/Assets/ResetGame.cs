using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour {

	public LevelData levelData;
	
	void Start()
	{
		levelData.currentDay = 1;
	}
}
