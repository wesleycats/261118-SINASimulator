using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour {

	public LevelData levelData;

	public int currentDay;

	private void Start()
	{
		levelData.currentDay += 1;
	}
}
