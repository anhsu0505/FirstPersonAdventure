using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabCode : MonoBehaviour
{
    private float launchForce = 20;
    public float raycastDist = 50; //range between item and player to be grabbed

    public Image handGrab; // reticle
    public Image handOpen;
    public Transform holdPoint; //player's hand location
    public Transform camTrans;


    AudioSource _audioSource;
    public AudioClip pickSound;
    public AudioSource audioSrc1;


    private bool reticleTarget = false;

    public LayerMask grabbableLayers; //define the layer can eb grabbed
    private int ignorePlayerLayer; //makesure layer not collide with player
    private int originalLayer; //save the original layer for picked

    private Transform heldObject = null;
    private Rigidbody heldRigidbody = null; //the held object is rigidbody

    public Animator animator;


    private void Start()
    {
        ignorePlayerLayer = LayerMask.NameToLayer("ignorePlayer"); //grab the ignoreplayer layer\
        _audioSource= GetComponent<AudioSource>();

        GameObject as1 = GameObject.FindGameObjectWithTag("pickupObjectSound");
        audioSrc1 = as1.GetComponent<AudioSource>();

        handOpen.enabled = false;
        handGrab.enabled = false;
    }
    public void Update()
    {
        //transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) //mouse if clicked
        {
            

            //_audioSource.PlayOneShot(pickSound);

            if (heldObject == null)
            {
                CheckForPickup(); //function below

                //pickSound.time = 0.2f;
            }
            else
            {
                LaunchObject();
                
            }

        }
    }


    void CheckForPickup()
    {
        RaycastHit hit;
        if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist, grabbableLayers))
        {
            StartCoroutine(PickUpObject(hit.transform)); //pass the transform of the object/collider that was picked
            
        }
    }

    IEnumerator PickUpObject(Transform _transform)
    {
        audioSrc1.PlayOneShot(pickSound);
        heldObject = _transform;
        originalLayer = heldObject.gameObject.layer; //save the original layer
        heldObject.gameObject.layer = ignorePlayerLayer;

        handGrab.enabled = true;

        heldRigidbody = heldObject.GetComponent<Rigidbody>();
        heldRigidbody.isKinematic = true; //ignore gravity after picked up

        float t = 0;
        while (t < 0.4f)
        {
            heldRigidbody.position = Vector3.Lerp(heldRigidbody.position, holdPoint.position, t);
            t += Time.deltaTime;
            yield return null;
        }
        SnapToHand();
    }


    void SnapToHand()
    {
        heldObject.position = holdPoint.position;
        heldObject.parent = holdPoint;
    }

    void LaunchObject()
    {
        StopAllCoroutines(); //if grab coroutine is still running stop and skip to end
        SnapToHand();

        heldRigidbody.isKinematic = false;
        //heldRigidbody.useGravity = true;
        heldObject.position = camTrans.position;
        heldRigidbody.AddForce(camTrans.forward * launchForce, ForceMode.VelocityChange); //throw the obejct in the direction the cam
        handGrab.enabled = false;
        heldObject.parent = null;
        StartCoroutine(LetGo());
    }

    IEnumerator LetGo()
    {
        yield return new WaitForSeconds(.1f);
        heldObject.gameObject.layer = originalLayer; //reset physical layer
        heldObject = null;
    }


    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist, grabbableLayers))
        {
            if (!reticleTarget)
            {
                handOpen.enabled = true;
                reticleTarget = true;
                
            }

        }
        else if (reticleTarget)
        {
            handOpen.enabled = false;
            reticleTarget = false;
        }
    }
}

