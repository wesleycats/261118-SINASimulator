using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour {

    private Image image;

	void Awake () {
        image = GetComponent<Image>();
        image.fillAmount = 0;
	}

    public void UpdateDisplay(float percentage)
    {
        percentage /= 100;
        if (percentage < 0) percentage = 0;
        else if (percentage > 1) percentage = 1;
        image.fillAmount = percentage;
    }
}
