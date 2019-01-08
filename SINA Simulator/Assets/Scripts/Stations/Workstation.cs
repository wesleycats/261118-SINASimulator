using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workstation : Interactable {

	public ProductionTime production;
	public List<Item> items = new List<Item>();
	public enum WorkstationType { CoffeeMachine, Kitchen, Trunk, Trash }
	public WorkstationType workStationType;
	public float productionTime;

	Player playerClass;
	WorkstationManager wsManager;
	StationInventory inventory;

	private void Awake()
	{
		wsManager = FindObjectOfType<WorkstationManager>();
		playerClass = FindObjectOfType<Player>();
		if (workStationType != WorkstationType.Trash) inventory = transform.GetChild(0).GetComponent<StationInventory>();
	}

	private void Start()
	{
		InitItemList();
        if (workStationType != WorkstationType.Trash)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (!Queue.ItemList.Contains(items[i]))
                {
                    Queue.ItemList.Add(items[i]);
                }
            }
        }
    }

	public override void Use(Player player)
	{
		if (workStationType != WorkstationType.Trash)
		{
			if (player.equipedItems[0].GetItem != ItemType.None)
			{
				if (workStationType != WorkstationType.CoffeeMachine) return;

				if (!inventory.gameObject.activeSelf) DisplayInventory(true);
				return;
			}

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
			case WorkstationType.CoffeeMachine:

				for (int i = 0; i < wsManager.coffeeMachine.Count; i++)
				{
					items.Add(new Item(wsManager.coffeeMachine[i], production.productionTimes[0]));
				}

				break;
			case WorkstationType.Kitchen:

				for (int i = 0; i < wsManager.kitchen.Count; i++)
				{
					items.Add(new Item(wsManager.kitchen[i], production.productionTimes[1]));
				}

				break;
			case WorkstationType.Trunk:

				for (int i = 0; i < wsManager.trunk.Count; i++)
				{
					items.Add(new Item(wsManager.trunk[i], production.productionTimes[2]));
				}
				break;
			case WorkstationType.Trash:

				for (int i = 0; i < wsManager.trashCan.Count; i++)
				{
					items.Add(new Item(wsManager.trashCan[i], production.productionTimes[3]));
				}
				break;
			default:
				Debug.Log("No workstation type was given");
			break;
		}
	}

	private void InitProductionTime(WorkstationType type)
	{
		switch(type)
		{
			case WorkstationType.CoffeeMachine:
				productionTime = production.productionTimes[0];
				break;
			case WorkstationType.Kitchen:
				productionTime = production.productionTimes[1];
				break;
			case WorkstationType.Trunk:
				productionTime = production.productionTimes[2];
				break;
			case WorkstationType.Trash:
				productionTime = production.productionTimes[3];
				break;
		}
	}
}
