using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ_QueueTakeOut : MonoBehaviour
{
    private DJ_Queue queue;
    private GameObject customer;
    DJ_Customer c;
    DJ_CustomerMovement m;

    void Start()
    {
        queue = GetComponent<DJ_Queue>();
        queue.NextCustomer += GetNextCustomer;
    }

    void GetNextCustomer()
    {       

        customer = queue.GetCustomer();
        c = customer.GetComponent<DJ_Customer>();
        m = customer.GetComponent<DJ_CustomerMovement>();
        m.InPosition -= Order;
        m.InPosition += Order;
    }

    void Order()
    {
        m.InPosition -= Order;
        c.PlaceOrder();
    }
}
