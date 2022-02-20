using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
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
           if( sceneName == "MainMenu"){
             SceneManager.LoadScene("Level_1");
           }

           if( sceneName == "Level_1"){
             SceneManager.LoadScene("Level_2");
           }

           if( sceneName == "Level_2"){
             SceneManager.LoadScene("Level_3");
           }
            
       }
       
   }
}
