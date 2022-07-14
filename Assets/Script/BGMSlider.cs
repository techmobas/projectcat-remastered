using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class BGMSlider : MonoBehaviour
{   

    [SerializeField]private Slider volumeSlider;

    private AudioManager audioManager;
    
    private void Awake() {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Start() {
        if(!PlayerPrefs.HasKey("bgmVolume")){
            PlayerPrefs.SetFloat("bgmVolume", 1);
            Load();
        }

        else{
            Load();
        }
    }

    public void ChangeVolume(){
        audioManager.GetComponent<AudioSource>().volume = volumeSlider.value;
        Save();
    }

    private void Load(){
        volumeSlider.value = PlayerPrefs.GetFloat("bgmVolume");
    }

    private void Save(){
        PlayerPrefs.SetFloat("bgmVolume", volumeSlider.value);
    }
}
