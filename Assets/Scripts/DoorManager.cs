using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DoorManager : MonoBehaviour
{
    AudioSource _audiosource;
    public AudioClip doorLocked;
    public AudioClip doorUnlocked;
    public AudioSource audioSrc1;
    public AudioSource audioSrc2;

    //public Animator fadeOut;


    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        
    }


    public string loadLevel;


    void OnTriggerEnter(Collider other) {
       //if(other.gameObject.CompareTag("Player") && GlobalVariables.hasKey == true)
            if (other.tag == "Player" && GlobalVariables.hasKey == true)
            {
            //_audiosource.PlayOneShot(doorUnlocked);
            GameObject as1 = GameObject.FindGameObjectWithTag("doorUnLockedSound");
            audioSrc1 = as1.GetComponent<AudioSource>();
            audioSrc1.PlayOneShot(doorUnlocked);


            //StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

            Invoke("waitOneSecond", 2);

           //SceneManager.LoadScene(loadLevel);


       } else {
            //_audiosource.PlayOneShot(doorLocked);
            GameObject as2 = GameObject.FindGameObjectWithTag("doorLockedSound");
            audioSrc2 = as2.GetComponent<AudioSource>();
            audioSrc2.PlayOneShot(doorLocked);
        }
   }
/*
   IEnumerator LoadLevel(int levelIndex)
    {
        fadeOut.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(levelIndex);   
    }
*/
}
