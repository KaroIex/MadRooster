using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpikesFail : MonoBehaviour
{

    public Transform startPoint;
    public bool Move = false;
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    bool coronatimeXD = true;
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        posOffset = transform.position;
    }

    void Update()
    {
        if(Move)
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
            transform.position = tempPos;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (coronatimeXD && (other.gameObject.name == "Player" || other.gameObject.name == "Goose"))
        {
            StartCoroutine("StartPulsing");
            other.gameObject.GetComponent<Player>().TakeDamage(10);
        }


    }


    private IEnumerator StartPulsing()
    {
        coronatimeXD = false;
        yield return new WaitForSeconds(0.75f);
        coronatimeXD = true;
    }
}
