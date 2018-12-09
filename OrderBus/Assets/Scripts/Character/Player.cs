using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public List<Item> equipedItems = new List<Item>();
	bool test = false;

	[SerializeField] private int itemLimit = 1;
	private int equipItemIndex;

	public Item GetEquipedItem{
		get {
			return equipedItems[equipItemIndex];
		}		
	}

	public void SetEquipedItem(Item item, int value)
	{
		equipedItems[value] = item;

		if (equipedItems[0] == null)
		{
			DisplayItem(false);
		}
		else
		{
			DisplayItem(true);
		}
	}

	void Start()
	{
		equipedItems.Add(new Item(ItemType.coffee));
	}

	void Update()
	{

	}

	void DisplayItem(bool display)
	{
		GameObject coffee = this.gameObject.transform.GetChild(0).gameObject;
		if (display == true)
		{
			for (int i = 0; i < equipedItems.Count; i++)
			{
				if (equipedItems[i].GetItem == ItemType.coffee)
				{
					coffee.SetActive(true);
				}
			}
		}
		else
		{
			coffee.SetActive(false);
		}
	}
}
