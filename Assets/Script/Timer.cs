using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public TextMeshProUGUI currentTime;
    public TextMeshProUGUI bestTime;
    public float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime/60);
        int seconds = Mathf.FloorToInt(elapsedTime%60);
        timerText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
    public void SaveAndGetPlayerPrefs()
    {
        currentTime.text = timerText.text;
        if(elapsedTime > PlayerPrefs.GetFloat("Elapsed"))
        {
            PlayerPrefs.SetFloat("Elapsed", elapsedTime);
            PlayerPrefs.SetString("BestTime", currentTime.text);
        }
        if (PlayerPrefs.GetString("BestTime") == null)
        {
            bestTime.text = "00:00";
        }
        else
        {
            bestTime.text = PlayerPrefs.GetString("BestTime");
        }   
    }
}
