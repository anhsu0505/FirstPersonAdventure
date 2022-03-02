using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Hints : MonoBehaviour
{
    public GameObject hints;

    public AudioClip panelOpen;
    public AudioClip panelClose;
    public AudioSource audioSrc1;
    public AudioSource audioSrc2;


    void Start()
    {
        hints.SetActive(false);

        GameObject as1 = GameObject.FindGameObjectWithTag("AudioSource1");
        audioSrc1 = as1.GetComponent<AudioSource>();

        GameObject as2 = GameObject.FindGameObjectWithTag("AudioSource2");
        audioSrc2 = as2.GetComponent<AudioSource>();

        //audioSrc1 = GetComponent<AudioSource>();
        //audioSrc2 = GetComponent<AudioSource>();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Entered");
            hints.SetActive(true);
            audioSrc1.PlayOneShot(panelOpen);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Exited");
            hints.SetActive(false);
            audioSrc2.PlayOneShot(panelClose);
        }
    }
}