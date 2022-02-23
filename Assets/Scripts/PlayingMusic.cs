using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingMusic : MonoBehaviour
{
     private void Awake() 
    {
        if(FindObjectsOfType<PlayingMusic>().Length > 1)
        {
            Destroy(gameObject);
        } 
        //else 
        //{
        //    DontDestroyOnLoad(gameObject);
        //}
    }

}
