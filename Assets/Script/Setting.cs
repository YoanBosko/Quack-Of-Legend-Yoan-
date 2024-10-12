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
        PlayerPrefs.SetFloat("BGM", sliderBGM.value);
        PlayerPrefs.SetFloat("SFX", sliderSFX.value);
    }
    public void SetBGMVolume(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFX", volume);
    }

}
