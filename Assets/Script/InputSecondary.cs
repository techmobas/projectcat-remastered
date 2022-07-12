using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-2)]
public class InputSecondary : MonoBehaviour
{   
    public static InputSecondary Instance;
    private PausedAction touchControls;

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;

    private void Awake(){
        if(Instance == null){
            Instance = this;
        }

        touchControls = new PausedAction();
       
    }

    public void OnEnable(){
        touchControls.Enable();
        TouchSimulation.Enable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    public void OnDisable(){
        touchControls.Disable();
        TouchSimulation.Disable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    void Start() {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);

    
    }

    private void StartTouch(InputAction.CallbackContext context){
        Debug.Log("Touch started " + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null) OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context){
        Debug.Log("Touch ended" + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
         if (OnEndTouch != null) OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
    }

    private void FingerDown(Finger finger){
        if (OnStartTouch != null) OnStartTouch(finger.screenPosition, Time.time);
    }

    void Update() {
        Debug.Log(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches);
        foreach(UnityEngine.InputSystem.EnhancedTouch.Touch touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches){
            Debug.Log(touch.phase == UnityEngine.InputSystem.TouchPhase.Began);
        }    
    }
}
