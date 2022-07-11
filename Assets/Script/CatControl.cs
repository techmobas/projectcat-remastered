using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatControl : MonoBehaviour
{
    [SerializeField]private int hitPoints;
    private Transform spawnPos;
    private bool isGone;
    
    [Header ("Hats")]
    [SerializeField] private GameObject hat0;
    [SerializeField] private GameObject hat1;


    // void Awake() {
    //     hitPoints++;
    // }
    void Start(){
        
    }

    public void Tap(){
        hitPoints--;
        if (hitPoints == 3){
            hat0.SetActive(false);
            hat1.SetActive(true);
        }
        else if (hitPoints == 2){
            hat0.SetActive(true);
            hat1.SetActive(false);
        }
        else if (hitPoints == 1){
            hat0.SetActive(false);
            hat1.SetActive(false);
        }
    }
    
    void Update()
    {
        if(hitPoints <= 0 && !isGone){
            Destroyed();
        }
    }

    public void Respawn(Transform pos){
        spawnPos = pos;
    }

    void Destroyed(){
        isGone = true;
        CatBehaviour.Instance.CatDestroyed(spawnPos);
        Destroy(this.gameObject);
    }
}
