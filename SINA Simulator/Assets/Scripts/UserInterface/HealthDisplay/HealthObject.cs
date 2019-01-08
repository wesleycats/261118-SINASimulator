using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthObject : MonoBehaviour {

    [SerializeField]
    private Sprite healthUp;
    [SerializeField]
    private Sprite healthDown;
    private Image image;
    

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void HealthUp()
    {
        image.sprite = healthUp;
    }

    public void HealthDown()
    {
        image.sprite = healthDown;
    }
}
