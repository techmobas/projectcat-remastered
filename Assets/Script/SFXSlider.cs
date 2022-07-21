using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SFXSlider : MonoBehaviour
{   

    [SerializeField]private Slider volumeSlider;

    private AudioManager audioManager;
    
    private void Awake() {
        audioManager = FindObjectOfType<AudioManager>();

        if(!PlayerPrefs.HasKey("sfxVolume")){
            PlayerPrefs.SetFloat("sfxVolume", 1);
            Load();
        }

        else{
            Load();
        }
    }

    public void ChangeVolume(){
        audioManager.sfxVolume = volumeSlider.value;
        Save();
    }

    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("sfxVolume", volumeSlider.value);
    }
}