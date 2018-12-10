using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	[SerializeField] private int itemLimit = 1;

    public static Player instance;

	public List<Item> equipedItems = new List<Item>();

	private List<GameObject> items = new List<GameObject>();
	private PlayerInventory inventory;
	private int equipItemIndex = 0;
	private bool test = false;

    [HideInInspector]
    public long objectId;

	public Item GetEquipedItem{
		get {
			return equipedItems[equipItemIndex];
		}		
	}

	private void Awake()
	{
        instance = this;
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
