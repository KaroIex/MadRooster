using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
public class CameraScene1 : MonoBehaviour
{

    public Transform player;
    public float smooth;

    private Vector3 currVelocity;
    void Update()
    {


         Vector3 newCamPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
         transform.position = Vector3.SmoothDamp(transform.position, newCamPos, ref currVelocity, smooth);

    }
}