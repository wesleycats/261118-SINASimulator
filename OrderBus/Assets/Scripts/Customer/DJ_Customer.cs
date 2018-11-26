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

public class DJ_Customer : MonoBehaviour
{
    [SerializeField] private float nextActionTimer;

    private DJ_CustomerMovement movement;
    [SerializeField] private CustomerStates currentCustomerState = CustomerStates.Wandering;

    void Start()
    {
        movement = GetComponent<DJ_CustomerMovement>();
        StartCoroutine("NextAction");
    }

    public void SetState(CustomerStates state)
    {
        currentCustomerState = state;
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
