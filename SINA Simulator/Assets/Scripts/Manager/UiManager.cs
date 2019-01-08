using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiManager : MonoBehaviour {

	public LevelData levelData;
	public Text daysLeftText;

	// Use this for initialization
	void Start () {
		int days = 8 - levelData.currentDay;

		daysLeftText.text = days.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
