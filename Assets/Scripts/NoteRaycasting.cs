using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteRaycasting : MonoBehaviour
{
    private float raycastDist = 50;
    public Transform camTrans;

    public GameObject note;
    public GameObject introNote;
    private bool noteTarget = false;
    private bool noteCheck = false;
    public LayerMask noteLayer;

    public GameObject readMe;

    public RawImage reticle;

    private bool reticleTarget = false;

    void Start()
    {
        note.SetActive(false);
        readMe.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //mouse if clicked
        {

            if (noteTarget == true)
            {
                note.SetActive(true);
                noteCheck = true;
                readMe.SetActive(false);
            }

        }
        else if (Input.GetMouseButtonUp(0) && noteCheck == true)
        {
            note.SetActive(false);
        }
        else
        {
            noteTarget = false;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist, noteLayer))
        {
            noteTarget = true;
            reticle.color = Color.red;
            reticleTarget = true;

        }
        else if (reticleTarget)
        {
            reticle.color = Color.white;
            reticleTarget = false;
        }
    }
}
