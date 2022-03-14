using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject waterBallPrefab;
    public Animator playerAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("default_static") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("default_walk") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("default_fly")))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        playerAnimator.SetTrigger("Hit");
        Instantiate(waterBallPrefab, firePoint.position, firePoint.rotation);

    }
}
