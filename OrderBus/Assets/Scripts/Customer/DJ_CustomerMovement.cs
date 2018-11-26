using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJ_CustomerMovement : MonoBehaviour
{
    public Vector2 TargetPosition { get; set; }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, 0.002f);
    }

    public void Execute(CustomerStates state)
    {
        StartCoroutine(state.ToString());
    }

    IEnumerator Wandering()
    {
        TargetPosition = new Vector2(Random.Range(-20, 20), Random.Range(-20, 20));
        yield return null;
    }

    IEnumerator Approaching()
    {
        TargetPosition = new Vector2(1, 0);
        yield return null;
    }

    IEnumerator Queueing()
    {
        yield return null;
    }

    IEnumerator Waiting()
    {
        yield return null;
    }

    IEnumerator Leaving()
    {
        yield return null;
    }
}
