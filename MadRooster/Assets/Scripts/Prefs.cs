using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs : MonoBehaviour
{
   private float MusicVolume;

   public void Start()
   {
       PlayerPrefs.SetFloat("MusicVolume",0.75f);
   }
   public void Update()
   {
       return;
   }

}
