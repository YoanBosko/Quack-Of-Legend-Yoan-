using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;
    public GameObject parentGameObject;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            DontDestroyOnLoad(parentGameObject);
            audioSource.PlayOneShot(clip);
            SceneManager.LoadScene("MainMenu");
        }
    }
}