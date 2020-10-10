using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public int playerLives = 3;

    public Text scoreText;
    public Text livesText;
    public GameObject gameoverScreen;

    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KillPlayer()
    {
        if (playerLives > 0)
        {
            playerLives--;
            livesText.text = "lives: " + playerLives.ToString();
            RespawnPlayer();
        } else if (playerLives == 0)
        {
            GameOver();
        }

    }

    void GameOver()
    {
        gameoverScreen.SetActive(true);
    }

    void RespawnPlayer()
    {
        Vector3 spawnPoint = new Vector3(0, -3.25f);
        Instantiate(playerPrefab, spawnPoint, playerPrefab.transform.rotation);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "score: " + score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
