/*****************************************************************************
// File Name : LivesPlusScore.cs
// Author : Thomas Santini
// Creation Date : September 6th, 2025 
//
// Brief Description : This script controls the score, high score, and lives.
*****************************************************************************/
using TMPro;
using UnityEngine;

public class LivesPlusScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text deadText;
    [SerializeField] private int score;
    [SerializeField] private int lives;
    [SerializeField] private int highScore;
    [SerializeField] private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighScoreUpdate();
    }

    /// <summary>
    /// When called, this functin increases the score, and changes the text accordingly. If the current score goes
    /// higher than the high score, it changes the high score and text accordingly as well.
    /// </summary>
    public void AddScore()
    {
        score += 20;
        scoreText.text = "Score: " + score.ToString();
        HighScoreUpdate();
        //if (score >= highScore)
        //{
            //highScore = score;
            //highScoreText.text = "High Score: " + highScore.ToString();
        //}
    }

    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if (score > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
                highScoreText.text = "High Score: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
            }
            else
            {
                highScoreText.text = "High Score: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("SavedHighScore").ToString();
        }
    }

    /// <summary>
    /// When called, this function decreases the lives the player has, and changes the text accordingly, unless
    /// they have no more lives, and the text will just say DEAD.
    /// </summary>
    public void DecreaseLives()
    {
        lives--;
        if (lives <= 0)
        {
            livesText.text = "DEAD";
        }
        else
        {
            livesText.text = "Lives: " + lives.ToString();
        }
    }

    /// <summary>
    /// When the player's lives reach zero, they can no longer play, and the text that tells them to restart appears.
    /// </summary>
    void Update()
    {
        if (lives <= 0)
        {
            player.SetActive(false);
            deadText.gameObject.SetActive(true);
        }
    }
}
