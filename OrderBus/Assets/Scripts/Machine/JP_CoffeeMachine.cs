using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JP_CoffeeMachine : JP_Interactable {

	public List<Item> items;

	WorkstationManager wsManager;

	private void Awake()
	{
		wsManager = FindObjectOfType<WorkstationManager>();
	}

	private void Start()
	{
		items = new List<Item>();

		for (int i = 0; i < wsManager.coffeeMachine.Count; i++)
		{
			items.Add(new Item(wsManager.coffeeMachine[i]));
		}
	}

	public override void Use(Player player)
    {
		player.SetEquipedItem(items[0],0);

		// TODO
		// FIX THAT items[0] becomes the item the player chose instead of hardcoded index 0
    }
}
