using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JH_Data : MonoBehaviour {

    [SerializeField]
    private int lives;
    [SerializeField]
    private GameObject _loseCondition, _healthDisplay;


    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
            if (lives < 0)
            {
                _healthDisplay.GetComponent<HealthDisplay>().SetLives(lives);
                _loseCondition.GetComponent<JH_LoseCondition>().Lose();
            }
        }
    }

}
