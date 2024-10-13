using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class GameState : MonoBehaviour
{
    public GameObject hpUP;
    public GameObject atkUP;
    public GameObject defUP;
    public GameObject spdUP;
    public GameObject knifeObject;
    public GameObject boneObject;
    public UnityEvent pauseEvent;
    public UnityEvent resumeEvent;
    public UnityEvent settingEvent;
    public UnityEvent deadEvent;
    public bool paused;
    public bool settings;
    public bool leveling;
    public bool gameover;
    public bool hpOn, atkOn, defOn, spdOn, knifeOn, boneOn;
    public AudioMixer audioMixer;
    private PlayerStatus playerStatus;
    private int slot;
    void Start()
    {
        audioMixer.SetFloat("BGM", PlayerPrefs.GetFloat("BGM"));
        audioMixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover && !paused && !leveling && Input.GetKeyDown(KeyCode.Escape))
        {
            paused = true;
            pauseEvent?.Invoke();
            Time.timeScale = 0f;
        }
        else if (settings == true && Input.GetKeyDown(KeyCode.Escape))
        {
            settings = false;
            settingEvent?.Invoke();
        }
        else if (paused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            paused = false;
            resumeEvent?.Invoke();
            Time.timeScale = 1f;
        }
    }
    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
    }
    public void SettingsEnter()
    {
        settings = true;
    }
    public void SettingExit()
    {
        settings = false;
    }
    public void ExitOrRetry()
    {
        Time.timeScale = 1f;
    }
    public void LevelUp()
    {
        leveling = true;
        slot = 0;
        while (slot < 4)
        {
            switch (Random.Range(1, 7))
            {
                case 1:
                    if (!hpOn)
                    {
                        hpUP.SetActive(true);
                        hpOn = true;
                        slot++;
                    }
                    break;
                case 2:
                    if (!atkOn)
                    {
                        atkUP.SetActive(true);
                        atkOn = true;
                        slot++;
                    }
                    break;
                case 3:
                    if (!defOn)
                    {
                        defUP.SetActive(true);
                        defOn = true;
                        slot++;
                    }
                    break;
                case 4:
                    if (!spdOn)
                    {
                        spdUP.SetActive(true);
                        spdOn = true;
                        slot++;
                    }
                    break;
                case 5:
                    if (!knifeOn)
                    {
                        knifeObject.SetActive(true);
                        knifeOn = true;
                        slot++;
                    }
                    break;
                case 6:
                    if (!boneOn)
                    {
                        boneObject.SetActive(true);
                        boneOn = true;
                        slot++;
                    }
                    break;
            }
        }
        Time.timeScale = 0f;
    }
    public void LevelUpExit()
    {
        leveling = false;
        hpOn = false;
        atkOn = false;
        defOn = false;
        spdOn = false;
        knifeOn = false;
        boneOn = false;
        hpUP.SetActive(false);
        atkUP.SetActive(false);
        defUP.SetActive(false);
        spdUP.SetActive(false);
        knifeObject.SetActive(false);
        boneObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void GameOverEnter()
    {
        gameover = true;
        StartCoroutine(GameOverDelay());
    }
    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(1f);
        deadEvent?.Invoke();
        Time.timeScale = 0f;
    }

}
