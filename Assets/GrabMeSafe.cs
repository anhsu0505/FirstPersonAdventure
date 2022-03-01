using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMeSafe : MonoBehaviour
{
     public GameObject triggeringWall;
     public GameObject safeObj;
     public bool isSafeActive = false;
    private void OnTriggerEnter(Collider other) {

    if (isSafeActive == false){
        if(other.gameObject.CompareTag("Frame"))
       {
          safeObj.SetActive(true);
          isSafeActive = true;
          Destroy(triggeringWall);
       }
    } 
   }
}
