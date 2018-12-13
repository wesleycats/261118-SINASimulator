using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is for testing game mechanics
/// </summary>
public class TestHotkey : MonoBehaviour {

	Data data;

	private void Awake()
	{
		data = GetComponent<Data>();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T))
		{
			data.health.SetLives(data.health.Lives-1);
		}
	}
}
