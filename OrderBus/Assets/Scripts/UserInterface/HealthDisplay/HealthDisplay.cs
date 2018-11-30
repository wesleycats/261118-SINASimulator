using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour {

    private int lives;
    private int maxLives;

    private List<HealthObject> healthObjects = new List<HealthObject>();


    void Start()
    {
        maxLives = transform.childCount;
        lives = maxLives;
        AcquireImages();
    }

    public void AcquireImages()
    {
        for(int i = 0; i < maxLives; i++)
        {
            healthObjects.Add(transform.GetChild(i).GetComponent<HealthObject>());
        }
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        for (int i = 0; i < maxLives; i++)
        {
            if(i < maxLives - lives) healthObjects[i].HealthDown();
            else healthObjects[i].HealthUp();
        }
    }

    public void SetLives(int amount)
    {
        if(lives >= 0 && lives <= maxLives)lives = amount;
        UpdateDisplay();
    }
}
