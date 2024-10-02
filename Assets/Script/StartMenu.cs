using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            DontDestroyOnLoad(gameObject.GetComponent<AudioSource>());
            audioSource.Play();
            SceneManager.LoadScene("MainMenu");
        }
    }
}