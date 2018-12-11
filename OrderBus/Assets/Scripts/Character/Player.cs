using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public List<Item> equipedItems = new List<Item>();

	private PlayerInventory inventory;
	private int equipItemIndex = 0;

	public Item GetEquipedItem{
		get {
			return equipedItems[equipItemIndex];
		}		
	}

	private void Awake()
	{
		inventory = transform.GetChild(0).GetComponent<PlayerInventory>();
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
