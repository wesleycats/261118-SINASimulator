using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {coffee, thea, choco, sandwhich, cookie, pie, blanket, diaper, poncho, none}
public class Item {

	private ItemType item;

	public Item(ItemType itemType){
		item = itemType;
	}

	public ItemType GetItem{ get { return item; } }
	
}
