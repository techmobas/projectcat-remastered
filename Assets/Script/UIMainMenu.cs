using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    private InputManager inputManager;
    private LevelManager levelManager;

    private void Awake(){
        inputManager = InputManager.Instance;
        levelManager = FindObjectOfType<LevelManager>();

    }

    private void OnEnable(){
        inputManager.OnStartTouch += ReTouch;
    }

    private void OnDisable(){
        inputManager.OnEndTouch -= ReTouch;
    }

    public void ReTouch(Vector2 screenPosition, float time){
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane);
        Vector3 worldCoordinates = Camera.main.ScreenToWorldPoint(screenPosition);
        worldCoordinates.z = 0;

        Collider2D scrn = Physics2D.OverlapPoint(worldCoordinates, LayerMask.GetMask("MainMenuScreen"));
        if (scrn != null){
            levelManager.LoadGame();
        }

    }
}
