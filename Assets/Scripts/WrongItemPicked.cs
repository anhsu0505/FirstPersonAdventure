using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//THIS IS TO BE attached to items that player hits but is not the key
//a panel will show up and tell player to look again

public class WrongItemPicked : MonoBehaviour
{
    public GameObject panel;
    public AudioClip panelOpen;
    public AudioClip panelClose;
    AudioSource audioSrc;

    void Start()
    {
        panel.SetActive(false);
        //audioSrc = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {

            panel.SetActive(true);
            //audioSrc.PlayOneShot(panelOpen);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            panel.SetActive(false);
            //audioSrc.PlayOneShot(panelClose);
        }
    }
}