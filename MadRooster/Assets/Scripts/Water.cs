using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    bool delay = true;
    public Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerStay2D(Collider2D other)
    {
        if ((playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("default_static") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("default_walk") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("default_fly"))
            && (delay && (other.gameObject.name == "Player")))
        {
            StartCoroutine("StartPulsing");
            other.gameObject.GetComponent<Player>().TakeDamage(5);
            return;
        }


        else if ((playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("fire_static_anim") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("fire_fly") ||
            playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("MoveAnim"))
            && (delay && (other.gameObject.name == "Player")))
        {
            StartCoroutine("StartPulsing");
            other.gameObject.GetComponent<Player>().TakeDamage(50);
            return;
        }

        else
            other.gameObject.GetComponent<Player>().grounded = true;

        




    }

    private IEnumerator StartPulsing()
    {
        delay = false;
        yield return new WaitForSeconds(0.75f);
        delay = true;
    }

}
