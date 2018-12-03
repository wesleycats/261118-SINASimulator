using UnityEngine.UI;
using UnityEngine;

public class mr_TriggerWin : MonoBehaviour {

    private Text winText;

    private void Start()
    {
        winText = GameObject.FindObjectOfType<Text>();
        winText.enabled = false;
    }

    public void TriggerWin()
    {
        Debug.Log("WIN!!!");
        winText.enabled = true;
    }
}
