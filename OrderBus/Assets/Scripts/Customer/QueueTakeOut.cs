using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueTakeOut : MonoBehaviour
{
    private Queue queue;
    private GameObject customer;
    Customer c;
    CustomerMovement m;
    OrderDisplayer d;

    void Start()
    {
        queue = GetComponent<Queue>();
        d = GetComponent<OrderDisplayer>();
        queue.NextCustomer += GetNextCustomer;
    }

    void GetNextCustomer()
    {
        customer = queue.GetCustomer();
        if (customer == null)
        {
            return;
        }
        c = customer.GetComponent<Customer>();
        m = customer.GetComponent<CustomerMovement>();
        m.InPosition -= Order;
        m.InPosition += Order;
    }

    void Order()
    {
        d.ShowOrder(c);
    }
}
