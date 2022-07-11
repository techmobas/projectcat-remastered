using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatBehaviour : MonoBehaviour
{
    public static CatBehaviour Instance;
    [SerializeField]private List<Transform> positionList = new List<Transform>();

    [SerializeField]private Dictionary<Transform, bool> spawnSpace = new Dictionary<Transform, bool>();
    [SerializeField]private List<GameObject> catPrefabs = new List<GameObject>();
    [SerializeField]private int catCount;
    
    private TimeManager timeManager;
    private LevelManager levelManager;
    private InputManager inputManager;
    private Camera cameraMain;

    private bool isTouching; 

    void Awake(){
        if(Instance == null){
            Instance = this;
        }
        Time.timeScale = 1;

        timeManager = FindObjectOfType<TimeManager>();
        levelManager = FindObjectOfType<LevelManager>();
        inputManager = InputManager.Instance;
        cameraMain = Camera.main;
    }

    private void OnEnable(){
        inputManager.OnStartTouch
    }

    private void OnDisable(){
        inputManager.OnEndTouch
    }

    void Start()
    {
        catCount = 0;
        spawnSpace.Clear();
        foreach(Transform pos in positionList){
            spawnSpace.Add(pos, false);
        }
        timeManager.StartTimer();
        StartCoroutine("StartGameplay");
    }


    void Update()
    {
        // if(Input.GetButtonDown("Fire1")){
        //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     Vector3 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        //     Collider2D obj = Physics2D.OverlapPoint(mousePos2D);
        //     RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        //     if(hit.collider != null && obj.TryGetComponent(out CatControl cat)){
        //         cat.Tap(); 
        //     }



        if (catCount >= spawnSpace.Count){
            timeManager.StopTimer();
            levelManager.GameIsOver();
            StopCoroutine("StartGameplay");
            catCount = 0;
        }
        // if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
        //     Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

        //     Collider2D obj = Physics2D.OverlapPoint(touchPos);
        //     if(obj != null && obj.TryGetComponent(out CatControl cat)){
        //         cat.Tap();  
        //     }
        // }
    }

    public void ReTouch(Vector2 screenPosition, float time){
        Vector3 
    }

     IEnumerator StartGameplay(){
        yield return null;
        while(true){
            int rand = Random.Range(0, positionList.Count);
            if(!spawnSpace[positionList[rand]]){
                int i = Random.Range(0, catPrefabs.Count);
                GameObject catObj = Instantiate(catPrefabs[i], positionList[rand].position, Quaternion.identity);

                CatControl cat = catObj.GetComponent<CatControl>();
                cat.Respawn(positionList[rand]);

                spawnSpace[positionList[rand]] = true;
                catCount++;
            }else{
                continue;
            }
            yield return new WaitForSeconds(Random.Range(0.4f, 1f));
        }
    }

    protected internal void CatDestroyed(Transform pos){
        spawnSpace[pos] = false;
        catCount--;
    }
}
