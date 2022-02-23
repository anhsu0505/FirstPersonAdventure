using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{    
    public GameObject keyUI;
    //public AudioClip gotKeySound;    
    
    void Update()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            //play sfx For GotKey
            //_audiosource.PlayOneShot(gotKeySound);
            keyUI.SetActive(true);
            GlobalVariables.hasKey = true;
            Destroy(gameObject);
        }
    }
}
