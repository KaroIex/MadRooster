using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
       SceneManager.LoadScene(3); 
    }

    public void Options()
    {
       SceneManager.LoadScene(1); 
    }

    public void Exit()
    {
       Application.Quit();
       Debug.Log("Exiting the game.");
    }

}
