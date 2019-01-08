using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour {

    [Header("Name of the main scene")]
    [SerializeField]
    private string mainSceneName;

	public void LoadScene()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
