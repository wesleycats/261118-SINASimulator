using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JP_CoffeeMachine : JP_Interactable {
	[SerializeField]
	private Item item;

    public override void Use(Player player)
    {
        Debug.Log("Je gebruikt de coffee machine");
		player.SetEquipedItem(item,0);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
