using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerInteractor : Interactable
{
    Player playerClass;
    [SerializeField] private OrderDisplayer displayer;
    private List<Item> orders;

    void Awake()
    {
        playerClass = FindObjectOfType<Player>();
        orders = displayer.orderList;
    }

    public override void Use(Player player)
    {
        Item it = player.equipedItems[0];
        if (orders.Contains(it))
        {
            orders.Remove(it);
            displayer.RefreshOrder();
            player.SetEquipedItem(new Item(ItemType.None, 0f), 0);
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
