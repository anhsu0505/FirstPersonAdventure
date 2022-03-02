using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{    
    public GameObject keyUI;
    //AudioSource _audiosource;
    //public AudioClip gotKeySound;

    //public keypad _keypad;

    void Start()
    {
        //_audiosource = GetComponent<AudioSource>();

        //GameObject keyPad = GameObject.FindGameObjectWithTag("keypad");
        //_keypad = keyPad.GetComponent<keypad>();

        //gameObject.SetActive(false);
    }

    void Update()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);

        //if(GlobalVariables.safeboxIsOpen == true)
        //{
        //    gameObject.SetActive(true);
       // }

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            //_audiosource.PlayOneShot(gotKeySound);
            keyUI.SetActive(true);
            GlobalVariables.hasKey = true;
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}
