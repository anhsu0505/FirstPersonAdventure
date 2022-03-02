using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hints : MonoBehaviour
{
    public GameObject hints;

    public AudioClip panelOpen;
    public AudioClip panelClose;
    AudioSource audioSrc;


    void Start()
    {
        hints.SetActive(false);
        audioSrc = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Entered"); hints.SetActive(true);
            audioSrc.PlayOneShot(panelOpen);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Exited");
            hints.SetActive(false);
            audioSrc.PlayOneShot(panelClose);
        }
    }
}