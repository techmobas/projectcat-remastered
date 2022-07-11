using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI currentTimeText;

    [SerializeField]private float currentTime;
    [SerializeField]private float playerTime;

    private bool isTimerActive = false;

    public float GetCurrentTime(){
        return currentTime;
        
    }   

    public float GetBestTime(){
        playerTime = PlayerPrefs.GetFloat("BestTime");
        return playerTime;
    }  
    
    void Update()
    {
        if (isTimerActive == true){
           currentTime = currentTime + Time.deltaTime;
           BestTime();
        }
        
        TimeSpan time =  TimeSpan.FromSeconds(currentTime);
        // currentTimeText.text = time.Hours.ToString("00") + " : " + time.Minutes.ToString("00") + " : " + time.Seconds.ToString("00");
        currentTimeText.text = time.ToString(@"hh\:mm\:ss");
    }   

    public void StartTimer(){
        isTimerActive = true;
    }   

    public void StopTimer(){
        isTimerActive = false;
    }

    public void BestTime(){
        if (currentTime > playerTime){
            playerTime = currentTime;
            PlayerPrefs.SetFloat("BestTime", playerTime);
        }
    }

    public void ResetTimer(){
         currentTime = 0;
    }
}
