using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour {

	public GameManager gameManager;
	public InputManager input;
	public LevelData levelData;
	public GameObject pauseMenu;
	
	private bool gamePaused = false;

	private void Start()
	{
		input.OnInput += PauseGame;
	}

	public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

	void PauseGame(InputActions action, float axis)
	{
		if (action == InputActions.Pause)
		{
			PauseMenu(pauseMenu);
		}
	}

    void PauseMenu(GameObject menu)
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void MainMenu()
    {
		Reset();
        SceneManager.LoadScene(0);
    }

	public void NextLevel()
	{
		levelData.currentDay += 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Reset()
	{
		gameManager.ResetGame();
	}

	public bool GetGamePaused() { return gamePaused; }
}
