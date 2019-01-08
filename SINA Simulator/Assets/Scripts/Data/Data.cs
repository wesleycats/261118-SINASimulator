using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    [SerializeField] private int currentLives;
	[SerializeField] private float orderTimeMultiplier = 1;

    public HealthDisplay health;
	public LoseCondition loseCondition;


	public int Lives
	{
		get
		{
			return currentLives;
		}
	}

	void Update()
	{
		currentLives = health.Lives;

		if (currentLives < 1)
		{
			health.SetLives(currentLives);
			loseCondition.Lose();
		}
	}

	public void DecreaseHealth()
	{
		health.SetLives(health.Lives - 1);
	}

	public float OrderTimeMultiplier { get { return orderTimeMultiplier; } }
}
