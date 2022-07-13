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

    [Header("Particles")]
    [SerializeField] private ParticleSystem smokeEffects;
    [SerializeField] private ParticleSystem starEffects;


    // void Awake() {
    //     hitPoints++;
    // }
    void Start(){
        
    }

    public int GetHitPoints(){
        return hitPoints;
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

    public void PlaySmokeEffect(){
        if(smokeEffects != null){
            ParticleSystem instance = Instantiate(smokeEffects, transform.position, Quaternion.identity) as ParticleSystem;
            instance.Emit(1);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    public void PlayStarsEffect(){
        if(smokeEffects != null){
            ParticleSystem instance = Instantiate(starEffects, transform.position, Quaternion.identity) as ParticleSystem;
            instance.Emit(1);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
