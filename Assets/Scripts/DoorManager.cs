using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public string loadLevel;
   private void OnCollisionEnter(Collision other) {
       if(other.gameObject.CompareTag("Player") && GlobalVariables.hasKey == true){
           SceneManager.LoadScene(loadLevel);
       } else {
           //playsoundeffect door closed
       }
   }
}
