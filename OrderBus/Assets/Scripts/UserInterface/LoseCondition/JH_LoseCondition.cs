using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JH_LoseCondition : MonoBehaviour {

    [SerializeField]
    private Scene _mainMenu;
    private bool gameLost = false;
    public GameObject LoseCondition;


	public void Lose()
    {
        LoseCondition.SetActive(true);
        Time.timeScale = 0f;
        gameLost = true;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("JH_LoseCondition");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(_mainMenu.name);
    }

    public bool GetGameLost() { return gameLost; }
}
