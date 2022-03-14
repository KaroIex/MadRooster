using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
public class CameraControler : MonoBehaviour
{

    public Transform player;
    public float smooth;
    public Rotation boss;
    public bool isCutscene = false;
    private Vector3 currVelocity;
    void Update()
    {
        isCutscene = boss.isCutscene;
        if (isCutscene == false)
        {
         Vector3 newCamPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
         transform.position = Vector3.SmoothDamp(transform.position, newCamPos, ref currVelocity, smooth);
        }
        else
        {
            Vector3 newCamPos = new Vector3(boss.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newCamPos, ref currVelocity, smooth);
        }
    }
}
