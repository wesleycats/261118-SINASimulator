using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public LevelData levelData;

	// TODO make background on ui so it can scale
	public GameObject background;

	void Start () {
		Time.timeScale = 1f;
	}

	public void ResetGame()
	{
		levelData.currentDay = 1;
	}
}
