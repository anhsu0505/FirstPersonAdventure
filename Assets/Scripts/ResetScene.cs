using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene: MonoBehaviour
{
string sceneName;
   
    void Start()
    {
     
        Scene currentScene = SceneManager.GetActiveScene();
        
        sceneName = currentScene.name;
    }

     private void OnTriggerEnter(Collider other) {

       if(other.gameObject.CompareTag("Player"))
       {   
             SceneManager.LoadScene(sceneName);
       }
       
   }
}
