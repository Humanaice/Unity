using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public List<GameObject> targets;
    //public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    //public TextMeshProUGUI livesText;
    public GameObject titleScreen;
    public GameObject gameScreen;
    public Button restartButton;
    public Slider HealthBar;

    public bool isGameActive;
    public int lives = 3;

    //private int score;
    public float spawnRate = 2.0f;

    public GameObject pauseScreen;
    private bool paused;

    [SerializeField] List<GameObject> balls;
    private float xRange = 20.0f;
    private float spawnTime = 2.0f;
    [SerializeField] float ySpawnPos = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.maxValue = lives;
        HealthBar.value = 0;
        HealthBar.fillRect.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }

    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        //restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        //score = 0;
        titleScreen.SetActive(false);
        gameScreen.SetActive(true);
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        //UpdateScore(0);
        UpdateLives(0);
    }
    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            //Physics Paused
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnTime);
            int index = Random.Range(0, balls.Count);

            if (isGameActive)
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

    public void UpdateLives(int livesToAdd)
    {
        lives += livesToAdd;
        HealthBar.value = lives;
        
        //livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            GameOver();
        }
    }

}
