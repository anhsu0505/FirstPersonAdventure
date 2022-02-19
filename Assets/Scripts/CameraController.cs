using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject looker;

    private Vector3 offset;
    void Start()
    {
        offset = transform.position - looker.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = looker.transform.position + offset;
    }
}
