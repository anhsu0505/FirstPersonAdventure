using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{    void Update()
    {
        transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            GlobalVariables.hasKey = true;
            Destroy(gameObject);
        }
    }
}
