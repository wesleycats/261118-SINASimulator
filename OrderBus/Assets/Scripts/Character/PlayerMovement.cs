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
    private Vector3 oldMovement;
	private Vector3 movement;

    [Header("Ship Movement Properties")]
    private bool canSendNetworkMovement;
    private float timeBetweenMovementStart;
    private float timeBetweenMovementEnd;
    private Vector3 oldPosition;

    private void Awake()
	{
        canSendNetworkMovement = false;
        playerInput.OnInput += Move;
	}

	private void Move(InputActions inputAction, float axisAmount)	{
		if (inputAction == InputActions.Down || inputAction == InputActions.Up)
        {
			movement.y = axisAmount;
		}
        else if (inputAction == InputActions.Left || inputAction == InputActions.Right)
        {
			movement.x = axisAmount;
		}
	}

	private void Update()
	{
		movement *= friction * speed * Time.deltaTime;

		this.transform.position += movement;

        UpdatePlayerMovement();
    }

    private void UpdatePlayerMovement()
    {
        if (!canSendNetworkMovement)
        {
            if (NetworkManager.instance != null && (oldPosition.x != transform.position.x || oldPosition.y != transform.position.y || oldPosition.z != transform.position.z))
            {
                canSendNetworkMovement = true;
                StartCoroutine(StartNetworkSendCooldown());
            }
        }
    }

    private IEnumerator StartNetworkSendCooldown()
    {
        timeBetweenMovementStart = Time.time;
        yield return new WaitForEndOfFrame();
        SendNetworkMovement();
    }

    private void SendNetworkMovement()
    {
        timeBetweenMovementEnd = Time.time;

        // Send position to server.

        NetworkManager.instance.ChannelSend(new LocationUpdate(transform.position.x, transform.position.y, transform.position.z, (timeBetweenMovementEnd - timeBetweenMovementStart)));
        oldPosition = transform.position;

        canSendNetworkMovement = false;
    }
}
