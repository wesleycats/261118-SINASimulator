using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DJ_Queue : MonoBehaviour
{
    public delegate void NewCustomer();
    public event NewCustomer NextCustomer;

    private enum Side
    {
        Left = -1,
        Right = 1
    }

    [Header("On which side of the bus is the queue?")]
    [SerializeField] private Side side;
    [Header("Finetuner for the positions of the customers in the queue")]
    [SerializeField] private float offset;
    [Header("Maximum length of the queue")]
    [SerializeField] private int maxLength;
    [SerializeField] private List<GameObject> customers = new List<GameObject>();
    [SerializeField] private List<GameObject> list = new List<GameObject>();

    public GameObject GetCustomer()
    {
        if (customers.ElementAtOrDefault(0) != null)
        {
            return customers[0];
        }
        return null;
    }

    void RemoveCustomer()
    {
        customers.Remove(customers[0]);
        StartCoroutine("SetCustomerPositions");
    }

    IEnumerator SetCustomerPositions()
    {
        DJ_CustomerMovement m;
        int l = customers.Count;
        for (int i = 0; i < l; i++)
        {
            m = customers[i].GetComponent<DJ_CustomerMovement>();
            m.QueuePosition = i;
            m.TargetPosition = new Vector2((i + offset) * side.GetHashCode() * 0.2f, 0);
        }
        yield return null;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        GameObject o = other.gameObject;
        if (o.tag == "Customer" && !customers.Contains(o))
        {
            DJ_Customer c = o.GetComponent<DJ_Customer>();
            DJ_CustomerMovement m = o.GetComponent<DJ_CustomerMovement>();
            if (customers.Count < maxLength)
            {
                c.Leaving += RemoveCustomer;
                customers.Add(o);
                m.EndOfQueue = new Vector2(offset * side.GetHashCode() * 0.2f, 0);
                StartCoroutine("SetCustomerPositions");
                c.SetState(CustomerStates.Queueing);
                if (NextCustomer != null)
                {
                    NextCustomer();
                }
            }
            else
            {             
                m.TargetPosition = new Vector2((1.2f + offset) * side.GetHashCode(), 0);
                m.StopAllCoroutines();
                c.SetState(CustomerStates.Wandering);
            }
        }
    }
}
