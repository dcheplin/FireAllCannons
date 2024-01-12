using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterText;

    public int count = 0;
    public int levelGoal = 3;

    private void Start()
    {
        count = 0;
    }

    private void Update()
    {
        if (count >= levelGoal)
        {
            counterText.color = Color.green;
        }
        else
        {
            counterText.color = Color.white;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            count++;
            UpdateText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            count--;
            UpdateText();
        }
    }

    public void UpdateText()
    {
        counterText.text = "Gather: " + count + " / " + levelGoal;
    }
}
