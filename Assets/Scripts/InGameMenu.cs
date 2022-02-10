using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject gameOverMenu;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    int score = 0;

    private void Awake()
    {
        pauseButton.SetActive(true);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    
    //scoring and lives increasing here
    public void UpdateScore(int amount)
    {
        score += amount;
        scoreText.text = ("Score: " + score);
    }

    public void LivesLeft(float amount)
    {
        livesText.text = ("Lives: " + amount);
    }

    //menu's handling here
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverMenu.SetActive(true);
        finalScoreText.text = ("Final score: " + score);
        pauseButton.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void Rusume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        SceneManager.LoadScene(2);
        
    }
    
    public void Exit()
    {
        SceneManager.LoadScene(1);
    }
}
