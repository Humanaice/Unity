using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> balls;
    private float xRange = 20.0f;
    private float spawnTime = 2.0f;
    [SerializeField] float ySpawnPos = 20.0f;
    public bool isGameRunning;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //isGameActive = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        isGameRunning = false;
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = gameManager.spawnRate;
        isGameRunning = gameManager.isGameActive;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameRunning)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, balls.Count);

            if (isGameRunning)
            {
                Instantiate(balls[index], RandomSpawnPos(), balls[index].transform.rotation);
            }

        }
    }

    Vector3 RandomSpawnPos()
    {
        // Has to make a "new" Vector3 value
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
