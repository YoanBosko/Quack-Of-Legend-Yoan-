using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseScript : MonoBehaviour
{
    GameObject playerObject;
    public UnityEvent pauseEvent;
    public UnityEvent resumeEvent;
    public bool paused;
    public bool settings;
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
    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
    }
}
