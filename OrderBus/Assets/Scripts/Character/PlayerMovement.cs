using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private InputManager playerInput;
	[SerializeField]
	private float speed;
	[SerializeField]
	private float friction;
	private Vector3 movement;


	private void Awake()
	{
		playerInput.OnInput += Move;
	}

	private void Move(InputActions inputAction, float axisAmount)	{
		if (inputAction == InputActions.Down || inputAction == InputActions.Up) {
			movement.y = axisAmount;
		} else if (inputAction == InputActions.Left || inputAction == InputActions.Right) {
			movement.x = axisAmount;
		}
	}

	private void Update()
	{
		movement *= friction * speed * Time.deltaTime;
		this.transform.position += movement;
	}
}
