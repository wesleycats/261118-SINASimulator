using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
	/*
	public Action<InputActions, float> OnInput;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Use"))
		{
			SendInput(InputActions.Use, 0);
		}

		if (Input.GetButtonDown("Horizontal"))
		{
			if (Input.GetAxis("Horizontal") > 0)
			{
				SendInput(InputActions.Down, Input.GetAxis("Horizontal"));
			}
			else
			{
				SendInput(InputActions.Up, Input.GetAxis("Horizontal"));
			}
		}

		if (Input.GetButtonDown("Vertical"))
		{
			if (Input.GetAxis("Vertical") > 0)
			{
				SendInput(InputActions.Left, Input.GetAxis("Vertical"));
			}
			else
			{
				SendInput(InputActions.Right, Input.GetAxis("Vertical"));
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
}
public enum InputActions { Left, Up, Right, Down, Use };
*/
}