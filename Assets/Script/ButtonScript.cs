using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    private DestroyLoad destroyLoad;

    void Start()
    {
        destroyLoad = FindAnyObjectByType<DestroyLoad>();
    }
    public void LoadScene(string aValue)
    {
        //Melakukan perpindahan antar scene. Catatan: Scene yang dipanggil sudah didaftarkan di Build Setting
        SceneManager.LoadScene(aValue);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}