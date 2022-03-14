using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameOptions : MonoBehaviour
{
    public void Back()
    {
       SceneManager.LoadScene(3); 
    }
    public void MainMenu()
    {
       SceneManager.LoadScene(0); 
    }


}
