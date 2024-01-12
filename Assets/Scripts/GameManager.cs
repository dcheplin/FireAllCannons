using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button nextLevelButton;
    [SerializeField] Button restartButton;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject counter;
    public TextMeshProUGUI scoreText;

    [SerializeField] GameObject player;
    private PlayerController playerController;
    private ScoreCounter scoreCounterScript;
    private Counter counterScript;

    void Awake()
    {
        counterScript = counter.GetComponent<Counter>();
        playerController = player.GetComponent<PlayerController>();
        
        SetLevelGoal(SceneManager.GetActiveScene().buildIndex);

        scoreCounterScript = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
        //scoreCounterScript.AddScore(0, 0, 0);
    }

    public void ActivateUI(string objectName, bool value)
    {
        if (objectName == "MainMenu")
        {
            mainMenu.SetActive(value);
            scoreText.text = "Total score: " + scoreCounterScript.totalScore;

        }
        else if (objectName == "NextLevelButton")
        {
            nextLevelButton.gameObject.SetActive(value);
        }
        else if (objectName == "RestartButton")
        {
            restartButton.gameObject.SetActive(value);
        }
    }

    private void SetLevelGoal(int levelIndex)
    {
        if (levelIndex == 1)
        {
            counterScript.levelGoal = 3;
            playerController.charges = 3;
        }
        else if (levelIndex == 2)
        {
            counterScript.levelGoal = 4;
            playerController.charges = 4;
        }
        else if (levelIndex == 3)
        {
            counterScript.levelGoal = 3;
            playerController.charges = 5;
        }
        counterScript.UpdateText();
    }
}
