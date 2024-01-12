using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    //private GameManager gameManagerScript;
    public int totalScore = 0;

     void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void AddScore(int valueScore, bool valueStars, int charges, bool resetScore)
    {
        if (resetScore)
        {
            totalScore = 0;
        }
        else
        {
            totalScore = totalScore + valueScore + 3 * charges;

            if (valueStars)
            {
                totalScore += 15;
            }
        }
    }
}
