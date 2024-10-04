using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLoad : MonoBehaviour
{
    public bool mainMenuAudio;
    public bool settingsAudio;
    public bool startAudio;
    private GameObject audioMain;
    private GameObject audioSettings;
    private GameObject audioStart;
    void Start()
    {

    }

    void Update()
    {
        if (mainMenuAudio == true)
        {
            StartCoroutine(DelayMainMenuAudio());
        }
        if (settingsAudio == true)
        {
            StartCoroutine(DelaySettingsAudio());
        }
        if (startAudio == true)
        {
            StartCoroutine(DelayStartAudio());
        }
    }

    IEnumerator DelayMainMenuAudio()
    {
        audioMain = GameObject.Find("MainMenuConfirm");
        if (audioMain != null)
        {
            yield return new WaitForSeconds(2f);
            Destroy(audioMain);
            mainMenuAudio = false;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            mainMenuAudio = false;
        }
    }
    IEnumerator DelaySettingsAudio()
    {
        audioSettings = GameObject.Find("SettingsCancel");
        if (audioSettings != null)
        {
            yield return new WaitForSeconds(2f);
            Destroy(audioSettings);
            settingsAudio = false;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            settingsAudio = false;
        }
    }
    IEnumerator DelayStartAudio()
    {
        audioStart = GameObject.Find("SettingsCancel");
        if (audioStart != null)
        {
            yield return new WaitForSeconds(2f);
            Destroy(audioStart);
            startAudio = false;
        }
        else
        {
            yield return new WaitForSeconds(2f);
            startAudio = false;
        }
    }
}