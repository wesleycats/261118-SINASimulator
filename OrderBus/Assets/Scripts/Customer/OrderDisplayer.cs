using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderDisplayer : MonoBehaviour
{
    [Header("An array of sprite renderers for the order icons")]
    [SerializeField] private SpriteRenderer[] orders;
    [Header("The maximum amount of items a customer can order")]
    [SerializeField] private int maxItems;
    [Header("Whether or not customer can request multiples of the same item")]
    [SerializeField] private bool allowDuplicates;
    private List<Item> itemList;
    private Customer customer;

    // Use this for initialization
    void Start()
    {
        itemList = FakeMachine.ItemList;
    }

    public void ShowOrder(Customer c)
    {
		transform.GetChild(0).gameObject.SetActive(true);
        customer = c;
        c.Leaving += ClearOrder;
        int m = Random.Range(1, maxItems);
        int l = itemList.Count;
        float t = 2 * m;
        for (int i = 0; i < m; i++)
        {
            Item it = itemList[Random.Range(0, l)];
            if (!allowDuplicates)
            {
                for (int j = 0; j < i; j++)
                {
                    while (orders[j].sprite == Resources.Load<Sprite>(it.GetItem.ToString()))
                    {
                        it = itemList[Random.Range(0, l)];
                    }
                }
            }
            orders[i].sprite = Resources.Load<Sprite>(it.GetItem.ToString());
            t += it.GetTime;
        }
        c.WaitTime = t;
        c.PlaceOrder();
    }

    public void ClearOrder()
    {
		transform.GetChild(0).gameObject.SetActive(false);
		customer.Leaving -= ClearOrder;
        for (int i = 0; i < maxItems; i++)
        {
            orders[i].sprite = null;
        }
    }
}
