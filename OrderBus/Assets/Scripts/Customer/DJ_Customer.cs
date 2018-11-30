﻿using System.Collections;
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

public class DJ_Customer : MonoBehaviour
{
    [SerializeField] private float nextActionTimer;
    private DJ_CustomerMovement movement;
    [SerializeField] private CustomerStates currentCustomerState = CustomerStates.Wandering;

    public int WaitTime { get; set; }

    public delegate void LeavingQueue();
    public event LeavingQueue Leaving;

    void Start()
    {
        movement = GetComponent<DJ_CustomerMovement>();
        StartCoroutine("NextAction");
    }


    public void SetState(CustomerStates state)
    {
        currentCustomerState = state;
    }

    public void PlaceOrder()
    {
        // Placeholder of the order for testing purposes, next line will be replaced
        int waitTime = 5;
        StartCoroutine(WaitForOrder(waitTime));
    }

    IEnumerator WaitForOrder(int seconds)
    {
        GetComponent<CircleCollider2D>().enabled = false;
        currentCustomerState = CustomerStates.Waiting;
        yield return new WaitForSeconds(seconds);
        Leave();
        yield return null;
    }

    void Leave()
    {
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
        movement.Execute(currentCustomerState);
        yield return new WaitForSeconds(nextActionTimer);
        StartCoroutine("NextAction");
        yield return null;
    }
}