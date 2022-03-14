using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Pulsing : MonoBehaviour
{
    public Player player;
    private bool coronatimeXD;




    void Start()
    {
        coronatimeXD = true;
    }
    void Update()
    {
        if(coronatimeXD)
        {
            StartCoroutine("StartPulsing");
        }

    }


    private IEnumerator StartPulsing()
    {
        coronatimeXD = false;

        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector2(
            (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.025f, Mathf.SmoothStep(0f, 1f, i))),
            (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.025f, Mathf.SmoothStep(0f, 1f, i)))
            );
            yield return new WaitForSeconds((float)player.currentHealth/1000);
        }


        for (float i = 0f; i <= 1f; i += 0.1f)
        {
            transform.localScale = new Vector2(
            (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.025f, Mathf.SmoothStep(0f, 1f, i))),
            (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.025f, Mathf.SmoothStep(0f, 1f, i)))
            );
            yield return new WaitForSeconds((float)player.currentHealth/1000);
        }

        coronatimeXD = true;

    }
}
