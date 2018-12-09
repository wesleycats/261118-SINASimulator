using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MR_TimeLeft : MonoBehaviour
{
	public GameObject winPanel;

	[Tooltip("Time is in seconds")]
	[SerializeField] private float timeLimit = 120f;
	[SerializeField] private float timeLeft;

	private float timeProgress = 0;
	private bool isTimeUp = false;

    // Take juda's script to pass the timeProgress variable to
    private TimeDisplay timeDisplay;

    private void Start()
    {
        // Find the scripts
        timeDisplay = GameObject.FindObjectOfType<TimeDisplay>();

        timeLeft = timeLimit;
		winPanel.SetActive(false);
	}

	void FixedUpdate()
    {
        if (!isTimeUp)
        {
            if (timeLeft < 0)
            {
				winPanel.SetActive(true);
                isTimeUp = true;
                Time.timeScale = 0;
                return;
            }
			
            timeProgress += Time.deltaTime * (100 / timeLimit);

            timeLeft -= Time.deltaTime;

            if (timeProgress > 0)
            {
                // pass time progresstion
                timeDisplay.UpdateDisplay(timeProgress);

            }
        }
    }
}