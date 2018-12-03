using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JH_PauseMenu : MonoBehaviour {

    [SerializeField]
    private Scene _mainMenu;
    private bool gamePaused = false;
    public GameObject pauseMenu;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused) Resume();
            else Pause();
        }
	}

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(_mainMenu.name);
    }

    public bool GetGamePaused() { return gamePaused; }
}
