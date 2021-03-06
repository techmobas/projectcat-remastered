using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public bool isPaused = false;
      
    [Header("Game Over Screen")]
    public GameObject overScreen; 
    

    [Header("Pause Screen")]
    public GameObject pauseScreen;
    TimeManager timeManager;

    void Awake(){
        timeManager = FindObjectOfType<TimeManager>(); 
    }

    public void DeterminePause(){
        if (isPaused){
            PauseGame();
        }
        else{
            ResumeGame();
        }
    }

    public void LoadMenu(){
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
        pauseScreen.SetActive(false);
        overScreen.SetActive(false);
    }

    public void LoadGame(){
        isPaused = false;
        timeManager.ResetTimer();
        SceneManager.LoadScene("Game");
        overScreen.SetActive(false);
    }

    public void GameIsOver(){
        isPaused  = true;
        overScreen.SetActive(true);
    }

    public void PauseGame(){
        Time.timeScale = 0;
        isPaused = true;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame(){
        Time.timeScale = 1;
        isPaused = false;
        pauseScreen.SetActive(false);
    }

}
