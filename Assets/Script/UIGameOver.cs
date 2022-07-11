using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultTime;
    [SerializeField] private TextMeshProUGUI bestResultTime;

    private float currentTime;
    private float bestResult;

    TimeManager timeManager;

    void Awake() {
        timeManager = FindObjectOfType<TimeManager>();
    }

    void Start()
    {   
        bestResult = timeManager.GetBestTime();
    }

    void Update(){
        currentTime = timeManager.GetCurrentTime();
        
        timeManager.BestTime();   

        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        TimeSpan bestTime = TimeSpan.FromSeconds(bestResult);

        resultTime.text = time.ToString(@"hh\:mm\:ss");
        bestResultTime.text =  "BEST TIME  : \n" + bestTime.ToString(@"hh\:mm\:ss");
    }
}
