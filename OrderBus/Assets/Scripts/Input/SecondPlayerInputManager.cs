using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerInputManager : InputManager {

	public static SecondPlayerInputManager instance;

	// Use this for initialization
	void Awake () {
		instance = this;

		OnInput += DebugInput;
	}
	
	// Update is called once per frame
	public override void Update () {
		
	}

	public void SendInput(InputActions inputAction, float axis){
		if (OnInput != null)
		{
			OnInput(inputAction,axis);
		}
	}

	private void DebugInput(InputActions inputActions, float axisNumber)
	{
		Debug.Log("Input: " + inputActions + " Axis: " + axisNumber);
	}
}
