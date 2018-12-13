using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Coffee, Tea, Choco, Sandwich, Cookie, Pie, Blanket, Diaper, Poncho, None}
public class Item {

	private ItemType item;
	private float time;

	public Item(ItemType itemType, float productionTime){
		item = itemType;
		time = productionTime;
	}

	public ItemType GetItem{ get { return item; } }
	public float GetTime { get { return time; } }
	
}
