using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabCode : MonoBehaviour
{
    private float launchForce = 20;
    private float raycastDist = 50; //range between item and player to be grabbed

    public Image reticle;
    public Transform holdPoint; //player's hand location
    public Transform camTrans;
    public AudioSource pickObject;
    public AudioClip clip;

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
        pickObject = GetComponent<AudioSource>();
    }
    public void Update()
    {
        //transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);

        if (Input.GetMouseButtonDown(0)) //mouse if clicked
        {
            if (heldObject == null)
            {
                CheckForPickup(); //function below
            }
            else
            {
                LaunchObject();
                
            }

            //triggering drawer open animation
            //if(gameObject.GetComponent("Drawer") && heldObject == null)
           // {
            //    RaycastHit hit;
            //    if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, raycastDist, grabbableLayers))
            //    {

             ///       animator.SetTrigger("DoorOpen");
             //   }
          //  }
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
        heldObject = _transform;
        originalLayer = heldObject.gameObject.layer; //save the original layer
        heldObject.gameObject.layer = ignorePlayerLayer;

       


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
                reticle.color = Color.red;
                reticleTarget = true;
            }

        }
        else if (reticleTarget)
        {
            reticle.color = Color.white;
            reticleTarget = false;
        }
    }







    //private void OnTriggerEnter(Collider other) {
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        GlobalVariables.hasKey = true;
    //        Destroy(gameObject);
    //    }


}

