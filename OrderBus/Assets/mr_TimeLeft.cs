using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class mr_TimeLeft : MonoBehaviour {


    private bool isTimeUp = false;

    private TimeDisplay timeDisplay;

    // Time in seconds
    private float timeLimit = 120f;
    private float timeLeft = 120f;
    private float timeProgress = 100;


    private void Start()
    {
        timeDisplay = GameObject.FindObjectOfType<TimeDisplay>();
    }

    void Update () {
        if (!isTimeUp)
        {
            if(timeLeft < 0)
            {
                Debug.Log("Time's up!!!!");
                isTimeUp = true;
                Time.timeScale = 0;
            }


            timeProgress -= Time.deltaTime * (100 / timeLimit);

            timeLeft -= Time.deltaTime;

            if (timeProgress > 0)
            timeDisplay.UpdateDisplay(timeProgress);
        }
    }
}
