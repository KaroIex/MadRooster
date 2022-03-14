using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pausedMenuUI;
    public GameObject GUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    public void Resume()
    {
        pausedMenuUI.SetActive(false);
        Time.timeScale = 1f;
       // GUI.SetActive(true);
        GameIsPaused = false;
    }
    void Pause()
    {
        pausedMenuUI.SetActive(true);
       // GUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {

        SceneManager.LoadScene(0);
        Resume();
          
        
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Exiting the game.");
    }
}
