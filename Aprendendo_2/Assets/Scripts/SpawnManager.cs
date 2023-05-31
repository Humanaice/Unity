using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalprefabs;
    private float spawnRangeX = 20;
    private float spawnPositionZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    public float spawnSidesX = 50.0f;
    public float spawnRangeZ = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalTop", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalLeft", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalRight", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimalTop()
    {
        int animalIndex = Random.Range(0, animalprefabs.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPositionZ);

        Instantiate(animalprefabs[animalIndex], spawnPosition, animalprefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalLeft()
    {
        int animalIndex = Random.Range(0, animalprefabs.Length);
        Vector3 spawnPosition = new Vector3(spawnSidesX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));

        Instantiate(animalprefabs[animalIndex], spawnPosition, Quaternion.Euler(0, -90, 0));
    }

    void SpawnRandomAnimalRight()
    {
        int animalIndex = Random.Range(0, animalprefabs.Length);
        Vector3 spawnPosition = new Vector3(-spawnSidesX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));

        Instantiate(animalprefabs[animalIndex], spawnPosition, Quaternion.Euler(0, 90, 0));
    }
}
