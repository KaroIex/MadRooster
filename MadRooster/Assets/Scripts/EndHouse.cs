using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndHouse : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(4);           
    }
}
