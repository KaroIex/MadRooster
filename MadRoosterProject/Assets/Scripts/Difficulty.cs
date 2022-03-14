using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Difficulty : MonoBehaviour
{
    private int counter;
    public TextMeshProUGUI text;
    
    public void click()
    {   
        if(counter == 0)
        {
            text.text = "Also easy";
            counter++;
            return;
        }
        else if(counter == 1)
        {
            text.text = "It can't be easier than easy";
            counter++;
            return;
        }
        else if(counter == 2)
        {
            text.text = "Stop spamming that button";
            counter++;
            return;
        }
        else if(counter == 3)
        {
            text.text = "Easy";
            counter = 0;
            return;
        }
    }


}
