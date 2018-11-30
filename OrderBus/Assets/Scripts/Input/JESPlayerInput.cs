using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JESPlayerInput : MonoBehaviour {

	public Action<InputActions, float> OnInput;

	private void Start()
	{
		//OnInput += DebugInput;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButton("Use"))
		{
			SendInput(InputActions.Use, 0);
		}

		if (Input.GetButton("Vertical"))
		{
			if (Input.GetAxis("Vertical") < 0)
			{
				SendInput(InputActions.Down, Input.GetAxis("Vertical"));
			}
			else
			{
				SendInput(InputActions.Up, Input.GetAxis("Vertical"));
			}
		}

		if (Input.GetButton("Horizontal"))
		{
			if (Input.GetAxis("Horizontal") < 0)
			{
				SendInput(InputActions.Left, Input.GetAxis("Horizontal"));
			}
			else
			{
				SendInput(InputActions.Right, Input.GetAxis("Horizontal"));
			}
		}
	}

	private void SendInput(InputActions inputActions, float axisNumber)
	{
		if (OnInput != null)
		{
			OnInput(inputActions, axisNumber);
		}
	}

	private void DebugInput(InputActions inputActions, float axisNumber)
	{
		Debug.Log("Input: " + inputActions + " Axis: " + axisNumber);
	}
}
public enum InputActions { Left, Up, Right, Down, Use };