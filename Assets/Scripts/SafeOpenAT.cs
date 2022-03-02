using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeOpenAT : MonoBehaviour
{
    [SerializeField] public Animator platform;
    [SerializeField] public string platformMove = "SafeOpen";


    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag ("Player"))
        {
            platform.Play(platformMove, 0, 0.0f);
        }

    }
}
