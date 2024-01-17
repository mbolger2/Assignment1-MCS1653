using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //The name of the input button that will pause the game
    public string pauseInputName;

    //A static variable to keep track of wheter the gameis paused
    public static bool isPaused = false;

    //The object with the pause menu
    public GameObject pauseMenuObject;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(pauseInputName))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    //the function that will pause the game
    public void Pause()
    {
        pauseMenuObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //the function that will unpause the game
    public void UnPause()
    {
        pauseMenuObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
