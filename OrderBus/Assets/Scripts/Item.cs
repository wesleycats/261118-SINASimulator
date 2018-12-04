using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Coffee, Tea, Choco, Sandwitch, Cookie, Cake, Blanket, Diaper, Poncho, None}
public class Item {

	private ItemType item;
    private int time;

	public Item(ItemType itemType, int waitTime){
		item = itemType;
        time = waitTime;
	}

	public ItemType GetItem{ get { return item; } }
    public int GetTime { get { return time; } }
	
}
