using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Data/LevelData", order = 1)]
public class LevelData : ScriptableObject {

	public enum Difficulty { Easy, Normal, Hard }

	[Header("Which level is the player currently playing?")]
	[SerializeField] public int currentDay;

	[Header("Which workstation will be unlocked on which day?")]
	public List<GameObject> workstation;

	[Header("Difficulty for every day")]
	public List<Difficulty> levelDifficulty;

	[Header("Spawn X amount of customers per day.")]
	public List<int> customersPerDay = new List<int>();
}
