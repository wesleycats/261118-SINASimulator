using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workstation : Interactable {

	public List<Item> items = new List<Item>();
	public enum WorkstationType { coffeeMachine, kitchen, trunk, trash }
	public WorkstationType workStationType;

	WorkstationManager wsManager;
	StationInventory inventory;

	private void Awake()
	{
		wsManager = FindObjectOfType<WorkstationManager>();
		if (workStationType != WorkstationType.trash) inventory = transform.GetChild(0).GetComponent<StationInventory>();
	}

	private void Start()
	{
		InitItemList();
	}

	public override void Use(Player player)
	{
		if (workStationType != WorkstationType.trash)
		{
			if (!inventory.gameObject.activeSelf) DisplayInventory(true);
		}
		else
		{
			player.SetEquipedItem(items[0], 0);
		}
	}

	public void DisplayInventory(bool display)
	{
		inventory.gameObject.SetActive(display);
	}

	private void InitItemList()
	{
		switch (workStationType)
		{
			case WorkstationType.coffeeMachine:

				for (int i = 0; i < wsManager.coffeeMachine.Count; i++)
				{
					items.Add(new Item(wsManager.coffeeMachine[i]));
				}

				break;
			case WorkstationType.kitchen:

				for (int i = 0; i < wsManager.kitchen.Count; i++)
				{
					items.Add(new Item(wsManager.coffeeMachine[i]));
				}

				break;
			case WorkstationType.trunk:

				for (int i = 0; i < wsManager.trunk.Count; i++)
				{
					items.Add(new Item(wsManager.coffeeMachine[i]));
				}
				break;
			case WorkstationType.trash:

				for (int i = 0; i < wsManager.trashCan.Count; i++)
				{
					items.Add(new Item(wsManager.trashCan[i]));
				}
				break;
			default:
				Debug.Log("No workstation type was given");
			break;
		}
	}
}
