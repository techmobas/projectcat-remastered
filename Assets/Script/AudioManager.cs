using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    [Header("Meow")]
    [SerializeField] private AudioClip meowSFX;
    [SerializeField] [Range(0f, 1f)] private float meowVolume = 1f;
    
    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
    }

    public void PlayMeowSFX(){
        PlayClip(meowSFX, meowVolume);
    }

    void PlayClip(AudioClip clip, float volume){
        if(clip != null){
            Vector3 cameraPos = mainCamera.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
