using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void SettingsScene()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}