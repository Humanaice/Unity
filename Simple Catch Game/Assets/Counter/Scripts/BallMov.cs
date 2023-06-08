using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMov : MonoBehaviour
{
    private Rigidbody ballRb;
    private float upForce = 200;
    private GameManager gameManager;
    private bool balltouched = false;

    // Start is called before the first frame update
    void Awake()
    {
        ballRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ballRb.AddForce(Vector3.up * upForce * Time.deltaTime,ForceMode.Impulse);
        balltouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            if(!balltouched)
            {
                Debug.Log("Ball Touched the Ground");
                gameManager.UpdateLives(-1);
                balltouched = true;
            }
            
        } 
    }
}
