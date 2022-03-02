using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform target;


    void Update()
    {

        if (target != null)
        {
            transform.LookAt(target);
            transform.Rotate(0, 180, 0);
        }
    }
}
