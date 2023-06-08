using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;

    public ParticleSystem explosionParticle;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = 2;

    public int pointValue;
   


    // Start is called before the first frame update
    void Start()
    {
        //Gets the Rigidbody
        targetRb = GetComponent<Rigidbody>();
        // Get acess to GameManager Script
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Propells Object to the air
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //Makes the object Rotate in the Air
        targetRb.AddTorque(RandomTorque(), RandomTorque(),RandomTorque(), ForceMode.Impulse);
        //Location of where the box will spawn in the bottom half
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            if (gameObject.CompareTag("Bad"))
            {
                gameManager.UpdateLives(-1);
            }
            else if (gameObject.CompareTag("SpecialBox"))
            {
                gameManager.UpdateLives(1);
            }
            DestroyTarget();
        }
       
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.UpdateLives(-1);
        }
        
    }

    Vector3 RandomForce()
    {
        // Vector3.up Alredy has a value,so no need to add a "new" Vector3
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        // Has to make a "new" Vector3 value
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
    }
}
