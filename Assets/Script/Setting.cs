using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Setting : MonoBehaviour
{
    public Slider sliderBGM;
    public Slider sliderSFX;
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        sliderBGM.value = PlayerPrefs.GetFloat("BGM");
        sliderSFX.value = PlayerPrefs.GetFloat("SFX");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveToPlayerPrefs()
    {
        if (sliderBGM.value == -40)
        {
            PlayerPrefs.SetFloat("BGM", -80);
        }
        else
        {
            PlayerPrefs.SetFloat("BGM", sliderBGM.value);
        }
        if (sliderSFX.value == -40)
        {
            PlayerPrefs.SetFloat("SFX", -80);
        }
        else
        {
            PlayerPrefs.SetFloat("SFX", sliderSFX.value);
        }
        // PlayerPrefs.SetFloat("BGM", sliderBGM.value);
        // PlayerPrefs.SetFloat("SFX", sliderSFX.value);
    }
    public void SetBGMVolume(float volume)
    {
        if (volume == -40)
        {
            audioMixer.SetFloat("BGM", -80);
        }
        else
        {
            audioMixer.SetFloat("BGM", volume);
        }
    }
    public void SetSFXVolume(float volume)
    {
        if (volume == -40)
        {
            audioMixer.SetFloat("SFX", -80);
        }
        else
        {
            audioMixer.SetFloat("SFX", volume);
        }
        
    }

}
