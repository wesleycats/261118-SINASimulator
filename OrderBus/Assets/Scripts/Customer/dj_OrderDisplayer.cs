using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ_OrderDisplayer : MonoBehaviour
{
    private List<Sprite> itemList = new List<Sprite>();
    [Header("An array of sprite renderers for the order icons")]
    [SerializeField] private SpriteRenderer[] orders;
    [Header("The maximum amount of items a customer can order")]
    [SerializeField] private int maxItems;
    private DJ_Customer customer;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < maxItems; i++)
        {
            itemList.Add(Resources.Load<Sprite>("Item" + i));
        }
    }

    public void ShowOrder(DJ_Customer c)
    {
        customer = c;
        c.Leaving += ClearOrder;
        int m = Random.Range(1, maxItems);
        int l = itemList.Count;
        for (int i = 0; i < m; i++)
        {
            orders[i].sprite = itemList[Random.Range(0, l - 1)];
        }
        c.WaitTime = m * 2 + 1;
        c.PlaceOrder();
    }

    public void ClearOrder()
    {
        customer.Leaving -= ClearOrder;
        for (int i = 0; i < maxItems; i++)
        {
            orders[i].sprite = null;
        }
    }
}
