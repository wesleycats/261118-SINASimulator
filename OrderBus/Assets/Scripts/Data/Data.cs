using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    [SerializeField] private int lives;

    public HealthDisplay health;
	public LoseCondition loseCondition;

	public int Lives
	{
		get
		{
			return lives;
		}
	}

	void Update()
	{
		lives = health.Lives;

		if (lives < 1)
		{
			health.SetLives(lives);
			loseCondition.Lose();
		}
	}
}
