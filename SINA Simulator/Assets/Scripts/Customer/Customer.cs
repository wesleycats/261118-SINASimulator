using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CustomerStates
{
    Wandering,
    Approaching,
    Queueing,
    Waiting,
    Leaving
}

public class Customer : MonoBehaviour
{
    [Header("How long the customer will execute a movement action before starting the next")]
    [SerializeField] private float nextActionTimer;
    private CustomerMovement movement;
    [SerializeField] private CustomerStates currentCustomerState;

    public float WaitTime { get; set; }

    public delegate void LeavingQueue();
    public event LeavingQueue Leaving;

    void Awake()
    {
        currentCustomerState = CustomerStates.Wandering;
        movement = GetComponent<CustomerMovement>();
        StartCoroutine("NextAction");
    }

    public void SetState(CustomerStates state)
    {
        currentCustomerState = state;
    }

    public void PlaceOrder()
    {
        StartCoroutine(WaitForOrder(WaitTime));
    }

    IEnumerator WaitForOrder(float seconds)
    {
        GetComponent<CircleCollider2D>().enabled = false;
        currentCustomerState = CustomerStates.Waiting;
        yield return new WaitForSeconds(seconds);
        Leave();
        yield return null;
    }

    public void Leave()
    {
        StopCoroutine("WaitForOrder");
        currentCustomerState = CustomerStates.Leaving;
        if (Leaving != null)
        {
            Leaving();
        }
    }

    IEnumerator NextAction()
    {
        if (Random.Range(0f, 1f) > 0.85 && currentCustomerState == CustomerStates.Wandering)
        {
            currentCustomerState = CustomerStates.Approaching;
        }
        if (currentCustomerState == CustomerStates.Leaving && movement.LeftScreen)
        {
            currentCustomerState = CustomerStates.Wandering;
            movement.GetComponent<CircleCollider2D>().enabled = true;
            movement.LeftScreen = false;
        }
        movement.Execute(currentCustomerState);
        yield return new WaitForSeconds(nextActionTimer);
        StartCoroutine("NextAction");
        yield return null;
    }
}
