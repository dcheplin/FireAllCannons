using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class GameManager : MonoBehaviour
{
    public abstract class LevelParameters
    {
        // Key - level number, Value - amount of charges
        private Dictionary<int, int> LevelCharges1 = new Dictionary<int, int>();
        public Dictionary<int, int> LevelCharges { get; set; }
        public Dictionary<int, int> LevelGoal { get; set; } = new Dictionary<int, int>();

        

        

        // Key - level number, Value - level goal (amount of successfull cannonballs)
        private Dictionary<int, int> LevelGoal1 = new Dictionary<int, int>();
    }

    

    [SerializeField] Button nextLevelButton;
    [SerializeField] Button restartButton;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject counter;
    public TextMeshProUGUI scoreText;

    [SerializeField] GameObject player;
    private PlayerController playerController;
    private ScoreCounter scoreCounterScript;
    private Counter counterScript;
    int charges = 3;

    void Awake()
    {
        counterScript = counter.GetComponent<Counter>();
        playerController = player.GetComponent<PlayerController>();
        
        SetLevelGoal(SceneManager.GetActiveScene().buildIndex);

        scoreCounterScript = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
        //scoreCounterScript.AddScore(0, 0, 0);



    }

    private void SetLevelParameters()
    {
        
        /*LevelParameters.Add(1, 3);
        LevelParameters.Add(2, 4);
        LevelParameters.Add(3, 5);*/
    }


    private void Update()
    {
        // open main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(!mainMenu.activeSelf);
        }
    }


    void ShowRestartButton()
    {
        if (counterScript.count < counterScript.levelGoal && charges == 0)
        {
            ActivateUI("RestartButton", true);
        }
    }

    void ShowNextLevelButton()
    {
        if (counterScript.count >= counterScript.levelGoal)
        {
            //If goal reached, let change lvl
            ActivateUI("NextLevelButton", true);
            ActivateUI("RestartButton", false);
        }
    }


    // buttons callout
    public void ResetCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenNewLevel(int levelIndex)
    {
       // scoreCounterScript.AddScore(counterScript.count, starGatheringScript.gathered, playerController.charges, false);

        if (SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
        {
            // start next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }




    public void ActivateUI(string objectName, bool value)
    {
        
        if (objectName == "NextLevelButton")
        {
            nextLevelButton.gameObject.SetActive(value);
        }
        else if (objectName == "RestartButton")
        {
            restartButton.gameObject.SetActive(value);
        }
    }

    public int GetAmountOfCharges()
    {
        int charges = 0;



        return charges;
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


