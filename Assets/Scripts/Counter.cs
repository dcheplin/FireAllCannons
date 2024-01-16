using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] UIHandler uiHandler;

    private int count;
    private int levelGoal;

    private void Start()
    {
        GameManager.Instance.SetGoalForLevel();
        count = GameManager.Instance.currentCount;
        levelGoal = GameManager.Instance.goalCount;

        uiHandler = GameObject.FindGameObjectWithTag("UIHandler").GetComponent<UIHandler>();

        UpdateTextAndStatus();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            count++;
            UpdateTextAndStatus();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            count--;
            UpdateTextAndStatus();
        }
    }

    public void UpdateTextAndStatus()
    {
        counterText.text = "Gather: " + count + " / " + levelGoal;

        if (count >= levelGoal)
        {
            counterText.color = Color.green;

            GameManager.Instance.isVictory = true;
            Invoke("CheckIfReachedGoal", 2);
        }
        else
            counterText.color = Color.white;
    }

    private void CheckIfReachedGoal()
    {
        if (count >= levelGoal)
            uiHandler.ShowNextLevelButton();
        else
            GameManager.Instance.isVictory = false;

    }
}
