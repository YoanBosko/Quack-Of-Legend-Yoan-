using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameState : MonoBehaviour
{
    GameObject playerObject;
    public UnityEvent pauseEvent;
    public UnityEvent resumeEvent;
    public UnityEvent settingEvent;
    public bool paused;
    public bool settings;
    public bool gameover;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerObject = GameObject.Find("Player");
        if (playerObject != null && Input.GetKeyDown(KeyCode.Escape) && paused == false)
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
        paused = false;
        gameover = false;
        Time.timeScale = 1f;
    }
    public void GameOverEnter()
    {
        gameover = true;
    }
}
