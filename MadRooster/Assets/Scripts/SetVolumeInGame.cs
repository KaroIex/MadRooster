using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolumeInGame : MonoBehaviour
{
    public AudioMixer mixer;
    public Scrollbar scrollbar;
    private bool muted = true;

    public void Start()
    {
        scrollbar.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void Update()
    {
        scrollbar.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void SetLevel(float scrollbarValue)
    {
        if(scrollbarValue == 0) scrollbarValue = 0.0001f;
        mixer.SetFloat("MusicVol",Mathf.Log10(scrollbarValue)*20);
        scrollbar.value = scrollbarValue;
        PlayerPrefs.SetFloat("MusicVolume",scrollbar.value);
    }

    public void Mute()
    {
        if(muted)
        {
            scrollbar.value = 0;
            var colors = GetComponent<Button> ().colors;
            colors.normalColor = Color.red;
            colors.selectedColor = Color.red;
            GetComponent<Button> ().colors = colors;
            muted = false;
            return;
        } 
        else
        {
            scrollbar.value = 0.5f;
            var colors = GetComponent<Button> ().colors;
            colors.normalColor = Color.white;
            colors.selectedColor = Color.white;
            GetComponent<Button> ().colors = colors;
            muted = true;
            return;
        }  
        
    }

}
