using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://forum.unity.com/threads/solved-correct-way-to-move-a-rigidbody-with-input.1087310/

public class PlayerController : MonoBehaviour
{
    private Rigidbody boxRb;

    [SerializeField] float speed = 5.0f;
    [SerializeField] float horizontalInput;
    public Vector3 movement;

    private float xRange = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        boxRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);

        if(transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        
    }

    void moveCharacter(Vector3 direction)
    {
        boxRb.velocity = direction * speed;
    }
}
