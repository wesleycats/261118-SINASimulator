using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationInventory : MonoBehaviour {
	
	public List<Item> items = new List<Item>();
	public Player player;
	public InputManager input;
	public WorkstationManager wsManager;
	private PlayerMovement playerMovement;
	private int index;

	private void Awake()
	{
		playerMovement = player.GetComponent<PlayerMovement>();
	}
	
	void Start ()
	{
		items = transform.parent.GetComponent<Workstation>().items;
	}

	private void OnEnable()
	{
		index = 0;
		input.OnInput += MenuControl;
		playerMovement.enabled = !playerMovement.enabled;
		input.movement = false;
	}

	private void OnDisable()
	{
		input.OnInput -= MenuControl;
		playerMovement.enabled = !playerMovement.enabled;
		input.movement = true;
	}

	private void MenuControl(InputActions inputAction, float axisAmount)
	{
		if (inputAction == InputActions.Up)
		{
			index += 1;

			if (index >= transform.childCount)
			{
				index = 0;
			}
			Debug.Log("Current Product: " + items[index].GetItem);
		}

		if (inputAction == InputActions.Down)
		{
			index -= 1;

			if (index < 0)
			{
				index = transform.childCount - 1;
			}
			Debug.Log("Current Product: " + items[index].GetItem);
		}

		if (inputAction == InputActions.Use)
		{
			player.SetEquipedItem(items[index], 0);
			this.gameObject.SetActive(false);
		}
	}
}
