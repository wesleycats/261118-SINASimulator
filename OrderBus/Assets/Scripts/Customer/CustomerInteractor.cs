using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInteractor : Interactable
{
	public Data data;
    Player playerClass;
    [SerializeField] private OrderDisplayer displayer;
    [SerializeField] private List<Item> orders;

	void Awake()
	{
		playerClass = FindObjectOfType<Player>();
	}
	
	public override void Use(Player player)
    {
		orders = displayer.orderList;
        Item it = player.equipedItems[0];
        if (orders.Contains(it))
        {
            orders.Remove(it);
            displayer.RefreshOrder();
            player.SetEquipedItem(new Item(ItemType.None, 0f), 0);
        }
        else
        {
			if (player.equipedItems[0].GetItem == ItemType.None) return;
			displayer.SendAway(false);
			data.DecreaseHealth();
		}
    }
}
