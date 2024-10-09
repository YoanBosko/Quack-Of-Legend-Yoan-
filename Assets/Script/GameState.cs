using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    void Start()
    {

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
