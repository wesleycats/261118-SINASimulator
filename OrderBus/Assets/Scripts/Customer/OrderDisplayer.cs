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
    [SerializeField] private OrderTimer timer;
    [SerializeField] private HealthDisplay health;
    [SerializeField] private LevelData lvlData;
    private List<Item> itemList;
    private Customer customer;
    public List<Item> orderList;

    // Use this for initialization
    void Start()
    {
        itemList = Queue.ItemList;
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].GetItem == ItemType.None)
            {
                itemList.RemoveAt(i);
            }
        }
    }

    public void ShowOrder(Customer c)
    {
        orderList = new List<Item>();
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
            orderList.Add(it);
        }
        if (lvlData.currentDay < 2)
        {
            t = 999999999f;
        }
        timer.SetTime(t);
        c.WaitTime = t;
        c.PlaceOrder();
        print(m);
    }

    public void RefreshOrder()
    {
        for (int i = 0; i < maxItems; i++)
        {
            orders[i].sprite = null;
        }
        int c = orderList.Count;
        if (c == 0)
        {
            SendAway(true);
            return;
        }
        for (int i = 0; i < c; i++)
        {
            orders[i].sprite = Resources.Load<Sprite>(orderList[i].GetItem.ToString());
        }
    }

    public void ClearOrder()
    {
        orderList = new List<Item>();
		transform.GetChild(0).gameObject.SetActive(false);
		customer.Leaving -= ClearOrder;
        for (int i = 0; i < maxItems; i++)
        {
            orders[i].sprite = null;
        }
    }

    public void SendAway(bool satisfied)
    {
        if (!satisfied)
        {
            health.SetLives(health.Lives - 1);
        }
        customer.Leave();
    }
}
