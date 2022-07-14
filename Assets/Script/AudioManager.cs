using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{   
    [SerializeField] [Range(0f, 1f)]public float sfxVolume;

    [Header("Meow")]
    [SerializeField] private AudioClip meowSFX;

    [Header("Hat")]
    [SerializeField] private AudioClip hatSFX;

    [Header("Bucket1")]
    [SerializeField] private AudioClip bucketOneSFX;

    [Header("Bucket2")]
    [SerializeField] private AudioClip bucketTwoSFX;
   
    private Camera mainCamera;

    private void Awake() {
        mainCamera = Camera.main;
    }

    public void PlayMeowSFX(){
        PlayClip(meowSFX);
    }

    public void PlayHatSFX(){
        PlayClip(hatSFX);
    }

    public void PlayBucketOneSFX(){
        PlayClip(bucketOneSFX);
    }
    public void PlayBucketTwoSFX(){
        PlayClip(bucketTwoSFX);
    }

    public void PlayClip(AudioClip clip){
        if(clip != null){
            Vector3 cameraPos = mainCamera.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, sfxVolume);
        }
    }
}
