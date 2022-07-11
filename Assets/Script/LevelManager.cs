using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    [Header("Game Over Screen")]
    public static bool isOver;
    public GameObject overScreen; 

    TimeManager timeManager;

    void Awake(){
        timeManager = FindObjectOfType<TimeManager>();
    }

    void Start(){
        
    }

    
    void Update()
    {
        
    }

    public void LoadGame(){
        timeManager.ResetTimer();
        SceneManager.LoadScene("Game");
    }

    public void GameIsOver(){
        overScreen.SetActive(true);
    }


}
