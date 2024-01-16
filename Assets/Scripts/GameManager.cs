using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Key - level number, Value - charges for this level
    //Dictionary<int, int> levelCharges = new Dictionary<int, int>();
    List<int> levelCharges = new List<int>();

    // Key - level number, Value - level goal (amount of successfull cannonballs)
    //Dictionary<int, int> levelGoal = new Dictionary<int, int>();
    List<int> levelGoal = new List<int>();


    public int sessionScore = 0;
    public int charges = 3;
    public int goalCount = 0;
    public int currentCount = 0;
    public bool isVictory = false;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        SetLevelParameters();
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void SetLevelParameters()
    {
        levelCharges.Add(0);
        levelCharges.Add(3);
        levelCharges.Add(4);
        levelCharges.Add(5);

        levelGoal.Add(0);
        levelGoal.Add(3);
        levelGoal.Add(4);
        levelGoal.Add(3);
    }

    public void SetChargesForLevel()
    {
        charges = levelCharges[SceneManager.GetActiveScene().buildIndex];
    }
    public void SetGoalForLevel()
    {
        goalCount = levelGoal[SceneManager.GetActiveScene().buildIndex];
    }
}



