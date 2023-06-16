using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ensure this script is executed first
[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }


    public bool sprintHeld { get; private set; }
    public bool jumpPressed { get; private set; }
    public bool activatePressed { get; private set; }
    public bool primaryShootPressed { get; private set; }
    public bool secondaryShootPressed { get; private set; }
    public bool weapon1Pressed { get; private set; }
    public bool weapon2Pressed { get; private set; }
    public bool commandPressed { get; private set; }


    private bool clear;

    //Singleton
    private static PlayerInput instance;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
            //return;
        }

        instance = this;
    }

    public static PlayerInput GetInstance()
    {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        ClearInput();
        ProcessInput();
    }

    void ProcessInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        sprintHeld = sprintHeld || Input.GetButton("Sprint");
        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        activatePressed = activatePressed || Input.GetKeyDown(KeyCode.E);

        primaryShootPressed = primaryShootPressed || Input.GetButtonDown("Fire1");
        secondaryShootPressed = secondaryShootPressed || Input.GetButtonDown("Fire2");

        weapon1Pressed = weapon1Pressed || Input.GetKeyDown(KeyCode.Alpha1);
        weapon2Pressed = weapon2Pressed || Input.GetKeyDown(KeyCode.Alpha2);

        commandPressed = commandPressed || Input.GetKeyDown(KeyCode.C);
    }

    private void FixedUpdate()
    {
        clear = true;
    }

    void ClearInput()
    {
        if(!clear)
        {
            return;
        }

        horizontal = 0;
        vertical = 0;
        mouseX = 0;
        mouseY = 0;

        sprintHeld = false;
        jumpPressed = false;
        activatePressed = false;

        primaryShootPressed = false;
        secondaryShootPressed = false;

        weapon1Pressed = false;
        weapon2Pressed = false;

        commandPressed = false;
    }
}
