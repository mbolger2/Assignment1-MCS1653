using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // The object with the instuctions menu
    public GameObject instructionMenu;

    // The object with the main menu
    public GameObject mainMenu;

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenInstructionsMenu()
    {
        mainMenu.SetActive(false);
        instructionMenu.SetActive(true);
    }

    public void OpenMainMenu()
    {
        instructionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
