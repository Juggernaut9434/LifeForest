﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    /*
    Pausing the Game Etc.
    Since GameIsPaused is static, we can use it in other scripts
    connecting UI buttons to Scripts as well
    */
    public static bool GameIsPaused = false;
    public bool MenuUI = false;

    public GameObject PauseMenuUI;

    void Start()
    {
        if(!MenuUI)
            PauseMenuUI.SetActive(false);
    }

    void Update() 
    {
        // Pressing P or Escape will Pause the Game
        if(Input.GetKeyDown("p") || Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    // making it public allows button to use this function
    public void Resume() 
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        
        // FPSController Hides cursor, this rehides it.
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Pause() 
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
        // FPSController Hides the Cursor. this unhides it
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        Debug.Log("Loading Game...");
        GameIsPaused = false;
        SceneManager.LoadScene("Level-1");
        
    }
    
    public void LoadMenu()
    {
        //On Menu, change time to normal
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Menu");
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // deprecated
        // Application.LoadLevel(Application.loadedLevel);

    }

    //private void switchScene(Object sceneToLoad)
    //{
    //    SceneManager.LoadScene(sceneToLoad.name);
    //}
}
