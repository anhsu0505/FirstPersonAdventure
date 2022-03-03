using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Hints : MonoBehaviour
{
    public GameObject hints;

    void Start()
    {
        hints.SetActive(false);

    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player" && GlobalVariables.hasKey == false)
        {
            Debug.Log("Player Entered");
            hints.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && GlobalVariables.hasKey == false)
        {
            Debug.Log("Player Exited");
            hints.SetActive(false);
        }
    }
}