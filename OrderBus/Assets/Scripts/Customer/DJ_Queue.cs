using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class dj_Queue : MonoBehaviour
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
    [SerializeField] private float offset = 0.2f;
    [Header("Maximum length of the queue")]
    [SerializeField] private int maxLength = 5;
    private List<GameObject> customers = new List<GameObject>();

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
        if (customers.ElementAtOrDefault(0) != null)
        {
            customers.Remove(customers[0]);
        }
        StartCoroutine("SetCustomerPositions");
    }

    IEnumerator SetCustomerPositions()
    {
        dj_CustomerMovement m;
        int l = customers.Count;
        for (int i = 0; i < l; i++)
        {
            m = customers[i].GetComponent<dj_CustomerMovement>();
            m.QueuePosition = i;
            m.TargetPosition = new Vector2(transform.position.x - ((transform.localScale.x/4 - i * offset) * side.GetHashCode()), 0);
        }
        if (NextCustomer != null)
        {
            NextCustomer();
        }
        yield return null;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        GameObject o = other.gameObject;
        if (o.tag == "Customer" && !customers.Contains(o))
        {
            dj_Customer c = o.GetComponent<dj_Customer>();
            dj_CustomerMovement m = o.GetComponent<dj_CustomerMovement>();
            if (customers.Count < maxLength)
            {
                c.Leaving += RemoveCustomer;
                customers.Add(o);
                m.EndOfQueue = new Vector2(transform.position.x - ((transform.localScale.x / 4) * side.GetHashCode()), 0);
                StartCoroutine("SetCustomerPositions");
                c.SetState(CustomerStates.Queueing);
            }
            else
            {             
                m.TargetPosition = new Vector2(12f + (offset * side.GetHashCode()), 0);
                m.StopAllCoroutines();
                c.SetState(CustomerStates.Wandering);
            }
        }
    }
}
