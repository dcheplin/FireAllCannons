using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class MainMenuButtons : MonoBehaviour
{
    private Button button;
    //public GameObject instructionsImage;
    private ScoreCounter scoreCounterScript;

    [SerializeField] GameObject counter = null;
    private Counter counterScript;

    [SerializeField] GameObject star = null;
    private StarGathering starGatheringScript;

    [SerializeField] GameObject player = null;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
       
        scoreCounterScript = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            counterScript = counter.GetComponent<Counter>();
            starGatheringScript = star.GetComponent<StarGathering>();
            playerController = player.GetComponent<PlayerController>();
        }
    }

    void OnButtonClick()
    {
        if (CompareTag("StartButton"))
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
            scoreCounterScript.AddScore(0, false, 0, true);
        }
        else if (CompareTag("ResetLevelButton"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
        /*else if (CompareTag("InstructionsButton"))
        {
            instructionsImage.SetActive(true);
        }
        else if (CompareTag("ExitButton"))
        {
            instructionsImage.SetActive(false);
        }*/
        else if (CompareTag("OptionsButton"))
        {
            //TODO: open options

        }
        else if (CompareTag("NextLevelButton"))
        {
            Time.timeScale = 1;
            scoreCounterScript.AddScore(counterScript.count, starGatheringScript.gathered, playerController.charges, false);
            
            if (SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings)
            {
                // start next level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            /*else
            {
                // show total score
                GameObject scoreBoard = GameObject.Find("ScoreBoard");
                scoreBoard.SetActive(true);

                ScoreBoard scoreBoardScript = scoreBoard.GetComponent<ScoreBoard>();
                scoreBoardScript.playScoreBoard = true;
            }*/


        }
        else if (CompareTag("QuitButton"))
        {
            Time.timeScale = 1; 
            Application.Quit();
        }
    }
}
