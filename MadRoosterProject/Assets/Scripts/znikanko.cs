using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class znikanko : MonoBehaviour
{
    private bool time;
    public Player player;

    void Start()
    {
        time = true;
    }
    void Update()
    {
        if (time && player.number == 1)
        {
            StartCoroutine("StartPulsing");
        }

    }


    private IEnumerator StartPulsing()
    {
        time = false;

        for (int i = 0; i <= 255; i +=5)
        {
            GetComponent<Image>().color = new Color32((byte)i, (byte)i, (byte)i, 255);
            yield return new WaitForSeconds((0.015f));
        }


       for (int i = 255; i >= 0; i -= 5)
        {
            GetComponent<Image>().color = new Color32((byte)i, (byte)i, (byte)i, 255);
            yield return new WaitForSeconds(0.015f);
        }


        time = true;

    }
}

