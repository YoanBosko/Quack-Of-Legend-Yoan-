using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource soundFX;

    void Awake()
    {
        // DontDestroyOnLoad(gameObject);
    }
    public void SoundFx(AudioClip aValue)
    {
        soundFX.clip = aValue;
        soundFX.Play();
    }
}
