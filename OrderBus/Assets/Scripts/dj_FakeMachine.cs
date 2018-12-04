using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dj_FakeMachine : MonoBehaviour {


    [Header("Items that the machine produces")]
    [SerializeField] private ItemType[] items;
    public static List<Item> ItemList = new List<Item>();
    [Header("Wait Time of the machine")]
    [SerializeField] private int waitTime;


	// Use this for initialization
	void Start ()
    {
        int l = items.Length;
        for (int i = 0; i < l; i++)
        {
            ItemList.Add(new Item(items[i], waitTime));
        }
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
