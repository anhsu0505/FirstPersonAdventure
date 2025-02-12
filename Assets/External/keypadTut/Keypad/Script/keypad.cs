﻿//333333333333333333333333333333333333333333333333333333333333333333\\
//
//          Arthur: Cato Parnell
//          Description of script: control keypad button clicks and actions
//          Any queries please go to Youtube: Cato Parnell and ask on video. 
//          Thanks.
//
//33333333333333333333333333333333333333333333333333333333333333333\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypad : MonoBehaviour
{
    Timing _timing;
    //private GameObject keyObj;
    //public bool keypadOpen;

    [SerializeField] public Animator safeboxAnimator;
    [SerializeField] public string safeOpened = "SafeOpen";


    // *** CAN DELETE THESE ** \\
    // Used to hide joystick and slider
    [Header("Show/Hide Objects")]
    //public GameObject objectToDisable;
   // public GameObject objectToDisable2;

    // Object to be enabled is the keypad. This is needed
    public GameObject objectToEnable;

    // *** Breakdown of header(public) variables *** \\
    // curPassword : Pasword to set. Ive set the password in the project. Note it can be any length and letters or numbers or sysmbols
    // input: What is currently entered
    // displayText : Text area on keypad the password entered gets displayed too.
    // audioData : Play this sound when user enters in password incorrectly too many times

    [Header("Keypad Settings")]
    public string curPassword = "▲●●■■■";
    public string input;
    public Text displayText;
    public AudioSource audioData;

    //Local private variables
    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;

    //Colliders of the safebox door
    public Collider safeBoxDoorCollider;
    public Collider keyBoard;
    public Collider keyBoardBase;

    // Start is called before the first frame update
    public void Start()
    {
        //Cursor.lockState = CursorLockMode.None;
        btnClicked = 0; // No of times the button was clicked
        numOfGuesses = curPassword.Length; // Set the password length.

        safeBoxDoorCollider.GetComponent<BoxCollider>().enabled = true;
        keyBoard.GetComponent<BoxCollider>().enabled = true;
        keyBoardBase.GetComponent<BoxCollider>().enabled = true;

        //keyObj = GameObject.FindGameObjectWithTag("Key");

        _timing = FindObjectOfType<Timing>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (btnClicked == numOfGuesses)
        {
             //Debug.Log(curPassword.Length);
            if (input == curPassword)
            {
                //play sound effect CorrectPassword
                //safeboxAnimator.Play(safeOpened, 0, 0.0f);
                GlobalVariables.safeboxIsOpen = true;
                safeBoxDoorCollider.GetComponent<BoxCollider>().enabled = false;
                keyBoard.GetComponent<BoxCollider>().enabled = false;
                keyBoardBase.GetComponent<BoxCollider>().enabled = false;
                safeboxAnimator.SetTrigger(safeOpened);

                //objectToDisable.SetActive(true);
               // objectToDisable2.SetActive(true);
                objectToEnable.SetActive(false); 
                keypadScreen = false;
                
                input = "▲●●■■■";
                btnClicked = 6;

                //keyObj.gameObject.SetActive(true);


                Cursor.lockState = CursorLockMode.Locked;
                
            }
            else
            {
                //Reset input varible
                input = "";
                displayText.text = input.ToString();
                audioData.Play();
                _timing.PenalizeTime();
                btnClicked = 0;
            }

        }

    }

    void OnGUI()
    {
        // Action for clicking keypad( GameObject ) on screen
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var selection = hit.transform;

                if (selection.CompareTag("keypad")) // Tag on the gameobject - Note the gameobject also needs a box collider
                {
                    keypadScreen = true;

                    var selectionRender = selection.GetComponent<Renderer>();
                    if (selectionRender != null)
                    {
                        keypadScreen = true;
                    }
                }

            }
        }

        // Disable sections when keypadScreen is set to true
        if (keypadScreen)
        {
            Cursor.lockState = CursorLockMode.None;
           //objectToDisable.SetActive(false);
            //objectToDisable2.SetActive(false);
            objectToEnable.SetActive(true);
        }

    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q": // QUIT
                //objectToDisable.SetActive(true);
                //objectToDisable2.SetActive(true);
                objectToEnable.SetActive(false);
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                 Cursor.lockState = CursorLockMode.Locked;
                break;

            case "C": //CLEAR
                input = "";
                btnClicked = 0;// Clear Guess Count
                displayText.text = input.ToString();
                break;

            default: // Buton clicked add a variable
                btnClicked++; // Add a guess
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }
}
