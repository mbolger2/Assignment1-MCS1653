using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // The object with the instuctions menu
    public GameObject instructionMenu;
    public GameObject instructionMenuTM;

    // The object with the main menu
    public GameObject mainMenu;
    public GameObject mainMenuTM;

    // The object with the level menu
    public GameObject levelSelect;
    public GameObject levelSelectTM;

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenInstructionsMenu()
    {
        mainMenu.SetActive(false);
        mainMenuTM.SetActive(false);
        instructionMenu.SetActive(true);
        instructionMenuTM.SetActive(true);
    }

    public void OpenMainMenu()
    {
        instructionMenu.SetActive(false);
        instructionMenuTM.SetActive(false);
        levelSelect.SetActive(false);
        levelSelectTM.SetActive(false);
        mainMenu.SetActive(true);
        mainMenuTM.SetActive(true);
    }

    public void OpenLevelSelectMenu()
    {
        mainMenu.SetActive(false);
        mainMenuTM.SetActive(false);
        levelSelect.SetActive(true);
        levelSelectTM.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
