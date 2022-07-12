using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    public Transform knob;
    public string sliderName;
    private Vector2 targetPos;

    void Start(){
        targetPos = knob.position;
    }

    void Update(){
        knob.position = Vector2.Lerp(knob.position, targetPos, Time.deltaTime * 7);
    }

    void OnTouchStay(Vector3 point){
        targetPos = new Vector2(point.x, targetPos.y);
    }



}
