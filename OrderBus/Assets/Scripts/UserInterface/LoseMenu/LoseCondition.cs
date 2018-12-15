using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour {

    private bool gameLost = false;
    public GameObject LosePanel;


	public void Lose()
    {
        LosePanel.SetActive(true);
        Time.timeScale = 0f;
        gameLost = true;
    }

	public void Retry()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public bool GetGameLost() { return gameLost; }
}
