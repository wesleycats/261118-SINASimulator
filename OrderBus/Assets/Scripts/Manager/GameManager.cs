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

		InitDay(levelData.currentDay);
	}

	public void InitDay(int day)
	{
		switch (day)
		{
			case 1:
				break;
			case 2:

				break;
			case 3:

				break;
			case 4:

				break;
			case 5:

				break;
			case 6:

				break;
			case 7:

				break;
			case 8:

				break;
			default:

			break;
		}
	}

	public void ResetGame()
	{
		levelData.currentDay = 1;
	}
}
