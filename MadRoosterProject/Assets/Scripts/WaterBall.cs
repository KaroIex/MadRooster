using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WaterBall : MonoBehaviour
{

    public Transform firePoint;
    public GameObject waterBallPrefab;
    public Animator playerAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("water_static") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("water_walk") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("water_fly")))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        playerAnimator.SetTrigger("WaterShoot");
        Instantiate(waterBallPrefab, firePoint.position, firePoint.rotation);
    
    }


}
