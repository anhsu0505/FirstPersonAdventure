using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    AudioSource _audiosource;
    public AudioClip doorLocked;
    public AudioClip doorUnlocked;
    
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
    }
    public string loadLevel;
   private void OnCollisionEnter(Collision other) {
       if(other.gameObject.CompareTag("Player") && GlobalVariables.hasKey == true){
           _audiosource.PlayOneShot(doorUnlocked);
           
           Invoke("waitOneSecond", 2);

           SceneManager.LoadScene(loadLevel);
       } else {
           _audiosource.PlayOneShot(doorLocked);
       }
   }

   public void waitOneSecond()
   {
       Debug.log("esperou");
   }
}
