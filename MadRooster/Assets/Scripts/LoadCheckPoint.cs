using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckPoint : MonoBehaviour
{
    CheckPoint checkPoint;
    SpriteRenderer spriteRenderer; 
        
    void Start()
    {
        checkPoint = GameObject.Find("GameManage").GetComponent<CheckPoint>();
        if (checkPoint == null)
        {
            Debug.LogError("oooo cie pierunie");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            checkPoint.UpdateCheckpoint(this.gameObject.transform);
            spriteRenderer.color = new Color(0.3f, 0.6f, 0.6f);
        }
    }

}