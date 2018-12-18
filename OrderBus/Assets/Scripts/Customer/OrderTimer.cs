using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderTimer : MonoBehaviour
{
    [SerializeField] private GameObject spr;
    [SerializeField] private OrderDisplayer displayer;
    private float secs;
    private Vector3 baseScale;

    void Start()
    {
        baseScale = spr.transform.localScale;
    }

    public void SetTime(float seconds)
    {
        secs = seconds;
        spr.transform.localScale = baseScale;
        StartCoroutine(CountDown(seconds));
    }

    IEnumerator CountDown(float s)
    {
        yield return new WaitForSeconds(1);
        Vector3 newScale = spr.transform.localScale;
        newScale.x -= baseScale.x / secs;
        spr.transform.localScale = newScale;
        s--;
        if (s > 0)
        {
            StartCoroutine(CountDown(s));
        }
        else
        {
            print("the customer is angry and walks away");
            ClearTime();
            displayer.SendAway(false);
        }
        yield return null;
    }

    public void ClearTime()
    {
        StopAllCoroutines();
        spr.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
