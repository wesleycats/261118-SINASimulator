using UnityEngine.UI;
using UnityEngine;

public class MR_TriggerWin : MonoBehaviour {

    [SerializeField] private Text winText;

    private void Start()
    {
        winText.enabled = false;
    }

    public void TriggerWin()
    {
        Debug.Log("WIN!!!");
        winText.enabled = true;
    }
}
