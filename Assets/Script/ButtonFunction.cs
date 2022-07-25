using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonFunction : MonoBehaviour
{
    private InputManager inputManager;

    private void Awake(){
        inputManager = InputManager.Instance;
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
    }
}
