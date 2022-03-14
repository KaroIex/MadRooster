using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    public Transform firePoint;
    public GameObject waterBallPrefab;
    public Animator playerAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("fire_static_anim") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("fire_fly") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("MoveAnim")))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        playerAnimator.SetTrigger("FireShoot");
        Instantiate(waterBallPrefab, firePoint.position, firePoint.rotation);

    }


}

