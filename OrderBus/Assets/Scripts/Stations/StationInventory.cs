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
	private Item inventory;
	private Workstation workstation;

	private void Awake()
	{
		playerMovement = player.GetComponent<PlayerMovement>();
		workstation = transform.parent.GetComponent<Workstation>();
	}
	
	void Start ()
	{
		items = transform.parent.GetComponent<Workstation>().items;
		if (workstation.workStationType == Workstation.WorkstationType.CoffeeMachine)
		{
			inventory = new Item(ItemType.None, 0);
		}
	}

	private void OnEnable()
	{
		index = 0;
		input.OnInput += MenuControl;
		playerMovement.enabled = false;
		input.movement = false;
		input.menu = true;
	}

	private void OnDisable()
	{
		input.OnInput -= MenuControl;
		playerMovement.enabled = true;
		input.movement = true;
		input.menu = false;
	}

	private void MenuControl(InputActions inputAction, float axisAmount)
	{
		if (player.GetComponent<Interact>().ClosestGameObject == null) return;

		// Fixes bug that item in inventory of coffeemachine instance get deleted when you interact with trashcan but doesnt allow to use kitchen
		//if (player.GetComponent<Interact>().ClosestGameObject.GetComponent<Workstation>().workStationType != Workstation.WorkstationType.CoffeeMachine) return;

		if (inputAction == InputActions.Use)
		{
			StartCoroutine(ProduceItem(items[index]));
		}

		if (!input.menu) return;

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
	}

	IEnumerator ProduceItem(Item item)
	{
		switch(workstation.workStationType)
		{
			case Workstation.WorkstationType.CoffeeMachine:

				//TODO fix bug where if you have an item and throw it away, while the coffeemachine has an item, it throws away the one from the coffee machine aswell
				if (inventory.GetItem == ItemType.None)
				{
					ShowWaitTime(item.GetTime);
					playerMovement.enabled = true;
					input.movement = true;
					input.menu = false;
					yield return new WaitForSeconds(item.GetTime);
					inventory = new Item(item.GetItem, item.GetTime);

					for (int i = 0; i < items.Count; i++)
					{
						if (item.GetItem.ToString() != transform.GetChild(i).name)
						{
							transform.GetChild(i).gameObject.SetActive(false);
						}
					}
					yield break;
				}

				if (!player.transform.GetChild(0).gameObject.activeSelf)
				{
					player.SetEquipedItem(item, 0);
					for (int i = 0; i < items.Count; i++)
					{
						transform.GetChild(i).gameObject.SetActive(true);
					}
					inventory = new Item(ItemType.None, 0);
					this.gameObject.SetActive(false);
				}
				break;

			case Workstation.WorkstationType.Kitchen:
				ShowWaitTime(item.GetTime);
				input.menu = false;
				yield return new WaitForSeconds(item.GetTime);
				player.SetEquipedItem(item, 0);
				this.gameObject.SetActive(false);
				break;

			case Workstation.WorkstationType.Trunk:
				ShowWaitTime(item.GetTime);
				input.menu = false;
				yield return new WaitForSeconds(item.GetTime);
				player.SetEquipedItem(item, 0);
				this.gameObject.SetActive(false);
				break;

			case Workstation.WorkstationType.Trash:
				ShowWaitTime(item.GetTime);
				input.menu = false;
				yield return new WaitForSeconds(item.GetTime);
				player.SetEquipedItem(item, 0);
				Debug.Log(player.equipedItems[0].GetItem);

				this.gameObject.SetActive(false);
				break;

			default:

			break;
		}
	}

	private void ShowWaitTime(float time)
	{
		Debug.Log("You need to wait " + time + " seconds");
	}
}
