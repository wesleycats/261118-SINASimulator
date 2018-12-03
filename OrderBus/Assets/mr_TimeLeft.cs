using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class mr_TimeLeft : MonoBehaviour
{


    private bool isTimeUp = false;

    // Take juda's script to pass the timeProgress variable to
    //private TimeDisplay timeDisplay;

        private mr_TriggerWin winTrigger;

    // Time in seconds
    private float timeLimit = 120f;
    private float timeLeft;
    private float timeProgress = 100;


    private void Start()
    {
        // Find the scripts
        //timeDisplay = GameObject.FindObjectOfType<TimeDisplay>();
        winTrigger = GameObject.FindObjectOfType<mr_TriggerWin>();

        // Log time and progress
        //InvokeRepeating("TimeLogging", 0f, 1f);

        timeLeft = timeLimit;
    }

    void FixedUpdate()
    {
        if (!isTimeUp)
        {
            if (timeLeft < 0)
            {
                Debug.Log("Time's up!!!!");
                isTimeUp = true;
                Time.timeScale = 0;
                return;
            }


            timeProgress -= Time.deltaTime * (100 / timeLimit);

            timeLeft -= Time.deltaTime;

            if (timeProgress > 0)
            {
                // pass time progresstion
                //timeDisplay.UpdateDisplay(timeProgress);

            } else
            {
                winTrigger.TriggerWin();
                // Trigger Win Condition
            }
        }

    }

    void TimeLogging()
    {
        Debug.Log("Time left : " + Mathf.Floor(timeLeft) + " seconds");
        Debug.Log("Progress : " + Mathf.Floor(timeProgress) + "%");
    }

}