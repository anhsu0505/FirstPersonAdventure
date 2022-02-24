using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{    
    public GameObject keyUI;
    //AudioSource _audiosource;
    //public AudioClip gotKeySound;
    
    void Start()
    {
        //_audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            //_audiosource.PlayOneShot(gotKeySound);
            keyUI.SetActive(true);
            GlobalVariables.hasKey = true;
            Destroy(gameObject);
        }
    }
}
