using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ_QueueTakeOut : MonoBehaviour
{
    private DJ_Queue queue;
    private GameObject customer;
    DJ_Customer c;
    DJ_CustomerMovement m;
    DJ_OrderDisplayer d;

    void Start()
    {
        queue = GetComponent<DJ_Queue>();
        d = GetComponent<DJ_OrderDisplayer>();
        queue.NextCustomer += GetNextCustomer;
    }

    void GetNextCustomer()
    {
        customer = queue.GetCustomer();
        if (c == null)
        {
            return;
        }
        c = customer.GetComponent<DJ_Customer>();
        m = customer.GetComponent<DJ_CustomerMovement>();
        m.InPosition -= Order;
        m.InPosition += Order;
    }

    void Order()
    {
        d.ShowOrder(c);
    }
}
