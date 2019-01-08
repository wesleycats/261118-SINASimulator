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
		equipedItems.Clear();
		equipedItems.Add(item);
		if (item.GetItem == ItemType.None)
		{
			DisplayInventory(false);
		}
		else
		{
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
					case ItemType.Coffee:
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
					case ItemType.Choco:
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
					case ItemType.Tea:
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
					case ItemType.Sandwich:
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
					case ItemType.Cookie:
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
					case ItemType.Pie:
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
					case ItemType.Blanket:
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
					case ItemType.Diaper:
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
					case ItemType.Poncho:
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
