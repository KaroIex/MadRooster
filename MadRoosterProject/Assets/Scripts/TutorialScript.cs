using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject moving;
    public GameObject jump;
    public GameObject jumpHigh;
    bool jumped = false;
    bool done = false;
    bool doublejumped = false;

    // Start is called before the first frame update
    void Start()
    {
        moving.SetActive(true); 
        jump.SetActive(false);  
        jumpHigh.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(doublejumped && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            jumpHigh.SetActive(false);
        }
        if(!doublejumped && jumped && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            doublejumped = true;        
        } 
        if (Input.GetAxis("Horizontal") > 0.01f || Input.GetAxis("Horizontal") < -0.01f)
        {
            moving.SetActive(false);
        } 
        if(!done && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            jump.SetActive(false);
            jumped = true;
            jumpHigh.SetActive(true);
            done = true;
        } 
    }

    void OnTriggerEnter2D()
    {
        if(!jumped) jump.SetActive(true);             
    }

}
