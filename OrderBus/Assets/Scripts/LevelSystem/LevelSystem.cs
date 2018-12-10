using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour {

    private enum Difficulty { Easy, Normal, Hard }


    [Header("Which level is the player currently playing?")]
    [SerializeField] private int _currentDay;

    [Header("Which workstation will be unlocked on which day?")]
    [SerializeField] private GameObject _workstationDay1;
    [SerializeField] private GameObject _workstationDay2;
    [SerializeField] private GameObject _workstationDay3;

    [Header("Difficulty of the day.")]
    [SerializeField] private Difficulty _levelDifficulty;

    [Header("Spawn X amount of customers per day.")]
    [SerializeField] private List<int> _customersPerDay = new List<int>();


    void Awake()
    {
        LevelDifficulty();
    }

    private void LevelDifficulty()
    {
        switch(_levelDifficulty)
        {
            case Difficulty.Easy:
                break;
            case Difficulty.Normal:
                break;
            case Difficulty.Hard:
                break;
        }
    }

}
