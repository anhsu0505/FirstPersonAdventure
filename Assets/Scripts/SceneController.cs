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

    //for menu interface use

    public void StartGame()
    {
      SceneManager.LoadScene("Level_1");
    }

    public void QuitGame()
    {
      Cursor.lockState = CursorLockMode.None;
      SceneManager.LoadScene("MainMenu");
    }

    //for in game coding
     private void OnTriggerEnter(Collider other) {

       if(other.gameObject.CompareTag("Player"))
       {
           if( sceneName == "MainMenu"){
             SceneManager.LoadScene("Level_1");
           }

           if(sceneName == "Level_1" && GlobalVariables.hasKey == true)
            {
             SceneManager.LoadScene("Level_2");
           }

           if( sceneName == "Level_2"){
             SceneManager.LoadScene("Level_3");
           }
            
       }
       
   }

}
