using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerMovement : MonoBehaviour
{
    public Vector2 TargetPosition { get; set; }
    public int QueuePosition { get; set; }
    public Vector2 EndOfQueue { get; set; }
    public bool LeftScreen { get; set; }
    private float side;

    [Header("The movement speed of the customer")]
    [SerializeField] [Range(1, 10)] private float movementSpeed = 3;

    public delegate void AtPosition();
    public event AtPosition InPosition;

    void Start()
    {
        QueuePosition = 4;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, 0.01f * movementSpeed);
        side = Mathf.Sign(transform.position.x);
    }

    public void Execute(CustomerStates state)
    {
        StartCoroutine(state.ToString());
    }

    IEnumerator Wandering()
    {
        TargetPosition = new Vector2(Random.Range(-10, 10), Random.Range(-10f, 10f));
        yield return null;
    }

    IEnumerator Approaching()
    {
        TargetPosition = new Vector2(7 * side, 0);
        yield return null;
    }

    IEnumerator Queueing()
    {
        if (QueuePosition == 0 && Vector3.Distance((Vector2)transform.position, EndOfQueue) < 0.02 && InPosition != null)
        {
            InPosition();
        }
        yield return null;
    }

    IEnumerator Waiting()
    {
        yield return null;
    }

    IEnumerator Leaving()
    {
        TargetPosition = new Vector2(20 * side, Random.Range(-2f, 2f));
        if (Vector3.Distance((Vector2)transform.position, TargetPosition) < 0.2)
        {
            LeftScreen = true;
        }
        yield return null;
    }
}
