using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Game Over Screen")]
    public static bool isOver;
    public GameObject overScreen; 
    

    [Header("Pause Screen")]
    public static bool isPaused;
    public GameObject pauseScreen;

    TimeManager timeManager;
    InputSecondary secondInput;
    InputManager primaryInput;

    void Awake(){
        timeManager = FindObjectOfType<TimeManager>();
        primaryInput = InputManager.Instance;
        secondInput = InputSecondary.Instance; 
    }

    public void DeterminePause(){
        if (isPaused){
            PauseGame();
        }
        else{
            ResumeGame();
        }
    }

    public void LoadGame(){
        isOver = false;
        timeManager.ResetTimer();
        SceneManager.LoadScene("Game");
        primaryInput.OnEnable();
        secondInput.OnDisable();
    }

    public void GameIsOver(){
        isOver = true;
        overScreen.SetActive(true);
        Time.timeScale = 0;
        secondInput.OnEnable();
        primaryInput.OnDisable();
    }

    public void PauseGame(){
        Time.timeScale = 0;
        isPaused = true;
        pauseScreen.SetActive(true);
        secondInput.OnEnable();
        primaryInput.OnDisable();
    }

    public void ResumeGame(){
        Time.timeScale = 1;
        isPaused = false;
        pauseScreen.SetActive(false);
        primaryInput.OnEnable();
        secondInput.OnDisable();
    }

}
