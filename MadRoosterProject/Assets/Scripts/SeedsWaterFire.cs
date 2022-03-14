using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SeedsWaterFire : MonoBehaviour

{
 
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public bool isWater;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;
    }


    void Update()
    {

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
   
            if (other.gameObject.name == "Player")
            {
            other.gameObject.GetComponent<Animator>().SetTrigger("seed");
            other.gameObject.GetComponent<Animator>().SetBool("waterFire",isWater);
                Destroy(this.gameObject);
            }
    }
}

        
