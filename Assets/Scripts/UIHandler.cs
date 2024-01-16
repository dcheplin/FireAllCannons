using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject nextLevelButton = null;
    //public GameObject NextLevelButton { get { return nextLevelButton; } }
    [SerializeField] GameObject restartButton = null;
    //public GameObject RestartButton { get { return restartButton; } }
    [SerializeField] GameObject mainMenu;

    private void Update()
    {
        // open main menu
        if (Input.GetKeyDown(KeyCode.Escape))
            mainMenu.SetActive(!mainMenu.activeSelf);
    }

    public void ShowRestartButton()
    {
        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }
    }

    public void ShowNextLevelButton()
    {
        if (nextLevelButton != null)
        {
            nextLevelButton.SetActive(true);
        }
    }

    public void OpenLevel(int levelIndex)
    {
        GameManager.Instance.isVictory = false;
        
        //TODO: add score board and score counting
        /*if (levelIndex > SceneManager.GetActiveScene().buildIndex)
        {
            GameManager.Instance.sessionScore += GameManager.Instance.currentCount + ;
        }
        else if (levelIndex == 0 || levelIndex == 1) 
        {
            GameManager.Instance.sessionScore = 0;
        }*/

        if (levelIndex != SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif    
    }
}
