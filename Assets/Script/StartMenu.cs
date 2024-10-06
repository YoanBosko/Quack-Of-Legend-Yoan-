using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class StartMenu : MonoBehaviour
{
    [Header("Main Settings")]
    public UnityEvent MainEvent;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            MainEvent?.Invoke();
        }
    }
}