using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int moveSpeed = 5;
    float lookSpeed = 3; // mouse sensitivity
    int jumpForce = 300;

    public Transform cameraTransform; // a reference to the camera transform
    float xRotation;
    float yRotation;
    Rigidbody _rigidbody;

    //The physics layers you want the player to be able to jump off of. Just dont include the layer the palyer is on.
    public LayerMask groundLayer;

    public Transform feetTransform; //Position of where the players feet touch the ground
    float groundCheckDist = .5f; //How far down to check for the ground. The radius of Physics.CheckSphere
    public bool grounded = false; //Is the player on the ground

    public Animator animator;

    void Start()
    {
        //animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>(); // Using GetComponent is expensive. Always do it in start and chache it when you can.
        Cursor.lockState = CursorLockMode.Locked; // Hides the mouse and locks it to the center of the screen.
    }

    void FixedUpdate()
    {
        //Creates a movement vector local to the direction the player is facing.
        Vector3 moveDir = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        moveDir *= moveSpeed;
        moveDir.y = _rigidbody.velocity.y; // We dont want y so we replace y with that the _rigidbody.velocity.y already is.
        _rigidbody.velocity = moveDir; // Set the velocity to our movement vector

        //The sphere check draws a sphere like a ray cast and returns true if any collider is withing its radius.
        //grounded is set to true if a sphere at feetTrans.position with a radius of groundCheckDist detects any objects on groundLayer within it
        grounded = Physics.CheckSphere(feetTransform.position, groundCheckDist, groundLayer);
    }

    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * 2; //Move left right rotation twice as fast as up down, change this to what feels right.
        xRotation -= Input.GetAxis("Mouse Y"); //Y is inverted
        xRotation = Mathf.Clamp(xRotation, -30, 30); //Keeps up/down head rotation realistic
        cameraTransform.localEulerAngles = new Vector3(xRotation, 0, 0) * lookSpeed;
        transform.eulerAngles = new Vector3(0, yRotation, 0);

        if (grounded && Input.GetButtonDown("Jump")) //if the player is on the ground and press Spacebar
        {
            _rigidbody.AddForce(new Vector3(0, jumpForce, 0)); // Add a force jumpForce in the Y direction
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Drawer")) {
            animator.SetTrigger("DoorOpen");

        }
    }
}