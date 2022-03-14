using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BossFire : MonoBehaviour
{

    public Transform firePoint;
    public GameObject waterBallPrefab;
    public Animator playerAnimator;
    public Rotation enemy;
    bool time = true;
    void Update()
    {

        if (enemy.CanIShoot == true)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (time)
        {
            StartCoroutine("StartPulsing");
        }

    }



    private IEnumerator StartPulsing()
    {
        time = false;
        playerAnimator.SetTrigger("Atack");
        Instantiate(waterBallPrefab, new Vector3(firePoint.position.x, firePoint.position.y,0), firePoint.rotation);
        yield return new WaitForSeconds(1f);
        time = true;

    }
}

