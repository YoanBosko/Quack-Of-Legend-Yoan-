using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class GameState : MonoBehaviour
{
    public UnityEvent pauseEvent;
    public UnityEvent resumeEvent;
    public UnityEvent settingEvent;
    public UnityEvent deadEvent;
    public bool paused;
    public bool settings;
    public bool leveling;
    public bool gameover;
    public AudioMixer audioMixer;
    private PlayerStatus playerStatus;
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
        // for (int i = 0; i < 4; i++)
        // {
        //     int randomNumber = Random.Range(0, playerStatus.listOfItem.Length);
        // }
        Time.timeScale = 0f;
    }
    public void LevelUpExit()
    {
        leveling = false;
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
