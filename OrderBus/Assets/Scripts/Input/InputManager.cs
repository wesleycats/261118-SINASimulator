using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour {

	public Action<InputActions, float> OnInput;

	public bool movement;
	public bool menu;

	private void Start()
	{
		//OnInput += DebugInput;
		movement = true;
	}

	// Update is called once per frame
	public virtual void Update()
	{
		if (Input.GetButtonDown("Use"))
		{
			SendInput(InputActions.Use, 0);
		}

		if (movement)
		{
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
		else if (menu)
		{
			if (Input.GetButtonDown("Vertical"))
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

			if (Input.GetButtonDown("Horizontal"))
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

		if (Input.GetButton("Pause"))
		{
			if (Input.GetButton("Pause"))
			{
				SendInput(InputActions.Pause, Input.GetAxis("Pause"));
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
public enum InputActions { Left, Up, Right, Down, Use, Pause };