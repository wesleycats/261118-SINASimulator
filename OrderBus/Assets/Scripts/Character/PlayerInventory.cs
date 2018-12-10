using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	public List<Item> equipedItems = new List<Item>();

	public List<Item> EquipedItem
	{
		get
		{
			return equipedItems;
		}
	}

	public void SetEquipedItem(Item item, int index)
	{
		if (item.GetItem == ItemType.none)
		{
			equipedItems.Clear();
			DisplayInventory(false);
		}
		else
		{
			equipedItems.Add(item);
			DisplayInventory(true);
		}
	}

	public void DisplayInventory(bool display)
	{
		if (display)
		{
			for (int i = 0; i < equipedItems.Count; i++)
			{
				switch (equipedItems[i].GetItem)
				{
					case ItemType.coffee:
						for (int j = 0; j < transform.childCount; j++)
						{
							if (transform.GetChild(j).name == "Coffee")
							{
								transform.GetChild(j).gameObject.SetActive(true);
							}
							else
							{
								transform.GetChild(j).gameObject.SetActive(false);
							}
						}
						break;
					case ItemType.choco:
						for (int j = 0; j < transform.childCount; j++)
						{
							if (transform.GetChild(j).name == "Choco")
							{
								transform.GetChild(j).gameObject.SetActive(true);
							}
							else
							{
								transform.GetChild(j).gameObject.SetActive(false);
							}
						}
						break;
					case ItemType.tea:
						for (int j = 0; j < transform.childCount; j++)
						{
							if (transform.GetChild(j).name == "Tea")
							{
								transform.GetChild(j).gameObject.SetActive(true);
							}
							else
							{
								transform.GetChild(j).gameObject.SetActive(false);
							}
						}
						break;
					case ItemType.sandwich:
						for (int j = 0; j < transform.childCount; j++)
						{
							if (transform.GetChild(j).name == "Sandwich")
							{
								transform.GetChild(j).gameObject.SetActive(true);
							}
							else
							{
								transform.GetChild(j).gameObject.SetActive(false);
							}
						}
						break;
					case ItemType.cookie:
						for (int j = 0; j < transform.childCount; j++)
						{
							if (transform.GetChild(j).name == "Cookie")
							{
								transform.GetChild(j).gameObject.SetActive(true);
							}
							else
							{
								transform.GetChild(j).gameObject.SetActive(false);
							}
						}
						break;
					case ItemType.pie:
						for (int j = 0; j < transform.childCount; j++)
						{
							if (transform.GetChild(j).name == "Pie")
							{
								transform.GetChild(j).gameObject.SetActive(true);
							}
							else
							{
								transform.GetChild(j).gameObject.SetActive(false);
							}
						}
						break;
					case ItemType.blanket:
						for (int j = 0; j < transform.childCount; j++)
						{
							if (transform.GetChild(j).name == "Blanket")
							{
								transform.GetChild(j).gameObject.SetActive(true);
							}
							else
							{
								transform.GetChild(j).gameObject.SetActive(false);
							}
						}
						break;
					case ItemType.diaper:
						for (int j = 0; j < transform.childCount; j++)
						{
							if (transform.GetChild(j).name == "Diaper")
							{
								transform.GetChild(j).gameObject.SetActive(true);
							}
							else
							{
								transform.GetChild(j).gameObject.SetActive(false);
							}
						}
						break;
					case ItemType.poncho:
						for (int j = 0; j < transform.childCount; j++)
						{
							if (transform.GetChild(j).name == "Poncho")
							{
								transform.GetChild(j).gameObject.SetActive(true);
							}
							else
							{
								transform.GetChild(j).gameObject.SetActive(false);
							}
						}
						break;
					default:
						{
							for (int j = 0; j < transform.childCount; j++)
							{
								transform.GetChild(j).gameObject.SetActive(false);
							}
						}
						break;
				}
			}
		}
		else
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
			gameObject.SetActive(false);
		}
	}
}
