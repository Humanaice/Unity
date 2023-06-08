using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public GameObject titleScreen;
    public Button restartButton;

    public bool isGameActive;
    public int lives = 3;

    private int score;
    private float spawnRate = 1.0f;

    public GameObject pauseScreen;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }

    }

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            //UpdateScore(5);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int livesToAdd)
    {
        lives += livesToAdd;
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        titleScreen.SetActive(false);
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
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
}
