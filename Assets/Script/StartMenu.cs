using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // private DestroyLoad destroyLoad;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            audioSource.Play();
            SceneManager.LoadScene("MainMenu");
        }
    }
    void Awake()
    {
        // destroyLoad = FindAnyObjectByType<DestroyLoad>();
        // destroyLoad.mainMenuAudio = true;
    }
}