using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public List<Item> equipedItems = new List<Item>();

	private PlayerInventory inventory;
	private int equipItemIndex;

	private void Start()
	{
		equipedItems.Add(new Item(ItemType.None, 0));
	}

	private void Awake()
	{
		inventory = transform.GetChild(0).GetComponent<PlayerInventory>();
	}

	private void Update()
	{
		if (inventory.isActiveAndEnabled)
		{
			equipedItems = inventory.equipedItems;
		}
	}

	public void SetEquipedItem(Item item, int index)
	{
		inventory.gameObject.SetActive(true);
		inventory.SetEquipedItem(item, index);
	}

	public void DisplayInventory(bool display)
	{
		inventory.DisplayInventory(display);
	}
}
