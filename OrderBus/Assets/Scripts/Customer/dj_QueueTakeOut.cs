using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dj_QueueTakeOut : MonoBehaviour
{
    private dj_Queue queue;
    private GameObject customer;
    dj_Customer c;
    dj_CustomerMovement m;
    dj_OrderDisplayer d;

    void Start()
    {
        queue = GetComponent<dj_Queue>();
        d = GetComponent<dj_OrderDisplayer>();
        queue.NextCustomer += GetNextCustomer;
    }

    void GetNextCustomer()
    {
        customer = queue.GetCustomer();
        if (c == null)
        {
            return;
        }
        c = customer.GetComponent<dj_Customer>();
        m = customer.GetComponent<dj_CustomerMovement>();
        m.InPosition -= Order;
        m.InPosition += Order;
    }

    void Order()
    {
        d.ShowOrder(c);
    }
}
