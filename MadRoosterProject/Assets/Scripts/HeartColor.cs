using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class HeartColor : MonoBehaviour
{
    public Animator playerAnimator;


    public Sprite newImage1;
    public Sprite newImage2;
    private Image myIMGcomponent;


    void Update()
    {
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("water_static"))
        {
            myIMGcomponent = this.GetComponent<Image>();
            myIMGcomponent.sprite = newImage1;
        }
        if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("fire_static_anim"))
        {
            myIMGcomponent = this.GetComponent<Image>();
            myIMGcomponent.sprite = newImage2;
        }


    }
}
