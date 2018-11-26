using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ_Queue : MonoBehaviour
{
    private enum Side
    {
        Left = -1,
        Right = 1
    }

    [Header("On which side of the bus is the queue?")]
    [SerializeField] private Side side;
    [Header("Finetuner for the positions of the customers in the queue")]
    [SerializeField] private float offset;
    private List<GameObject> customers = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject o = other.gameObject;
        
        if (o.tag == "Customer" && !customers.Contains(o))
        {
            DJ_Customer c = o.GetComponent<DJ_Customer>();
            DJ_CustomerMovement m = o.GetComponent<DJ_CustomerMovement>();
            if (customers.Count < 4)
            {
                print("Colliding");
                customers.Add(o);
                m.TargetPosition = new Vector2((customers.IndexOf(o) + offset) * side.GetHashCode() * 0.2f, 0);
                c.SetState(CustomerStates.Queueing);
            }
            else
            {             
                m.TargetPosition = new Vector2((1 + offset) * side.GetHashCode(), 0);
                m.StopAllCoroutines();
                c.SetState(CustomerStates.Wandering);
            }
        }
    }
}
