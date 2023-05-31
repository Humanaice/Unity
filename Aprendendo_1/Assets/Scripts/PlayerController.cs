using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Varibles
    //Moviment
    //Serialize Field its like public variable atribut but you can only use in the editor but you dont
    // want to ever use in a different class
    //Ex:If you have another class/another script that was ussing Player Controller and you want to 
    //change the speed value in the editor but not in the class itself

    //protected
    //A variable atribut that its like protected so that other scripts cannot see it but cripts that
    //inherited can use for exemple functions
    //Ex: Player Controller Inherited protected functions from MonoBehavior like Uptade() and Start()

    //const 
    //A variable atribut that its function its that the varible that it is atributed to it can not change
    //its value

    //read only
    //A variable atribut that is similar to const but you can change just once/like when you creat it

    //static
    //A variable atribut that is like a global varible, if you change its value it changes to the class
    //itself and not other instances of it

    [SerializeField] float speed;
    [SerializeField] private float horsePower = 0;
    [SerializeField] float rpm;
    public float turnSpeed = 30.0f;
    public float horizontalInput;
    public float forwardInput;

    private Rigidbody playerRb;
    [SerializeField] GameObject COM;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI RPMText;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    //Camera
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;

    public string inputID;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = COM.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //This is where wwe get player Input
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }

        if (IsOnGround())
        {

            //Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
            //Turning the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            //print speed
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f);
            speedometerText.SetText("Speed: " + speed + " mph");

            //print RPM
            rpm = Mathf.Round((speed % 30) * 40);
            RPMText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //FixedUpdate()
    //Usefull when you are trying to do movement and physics. It is callse before Update() calls, and 
    //actully happens when our game is triyng to calculate movement and physics

    //LateUpdate()
    //Usefull when you are trying to calculate the cameras position. Is called After Update() and Fixed-
    //Update(), so it goes after all the physics calculations

    //Awake
    //Useful when you want an object to do something when its called an not when its spawned(Start())

}
