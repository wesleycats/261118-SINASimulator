using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {coffee, thea, blanket, none}
public class Item : MonoBehaviour {

	private ItemType item;

	public Item(ItemType itemType){
		item = itemType;
	}

	public ItemType GetItem{ get { return item; } set { item = value; } }
	
}
