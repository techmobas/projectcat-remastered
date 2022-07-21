using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInstantiate : MonoBehaviour
{
   [SerializeField]private Object persistentScene;

   private void Awake() {
    SceneManager.LoadSceneAsync(persistentScene.name, LoadSceneMode.Additive);
   }

   [ContextMenu("ChangeScene")]
   public void NextScene(){
    SceneManager.UnloadSceneAsync("MainMenu");
    SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
   }
}
