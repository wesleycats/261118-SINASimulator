using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TimeLeft : MonoBehaviour
{
	public LevelData levelData;
	public GameObject winMenu;
	public GameObject endMenu;

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
		winMenu.SetActive(false);
	}

	void FixedUpdate()
    {
        if (!isTimeUp)
        {
            if (timeLeft < 0)
            {
				Win();
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

	private void Win()
	{
		if (levelData.currentDay >= 7)
		{
			endMenu.SetActive(true);
		} else
		{
			winMenu.SetActive(true);
		}
		isTimeUp = true;
		Time.timeScale = 0;
	}
}