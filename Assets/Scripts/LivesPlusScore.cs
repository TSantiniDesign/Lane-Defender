using TMPro;
using UnityEngine;

public class LivesPlusScore : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private int score;
    [SerializeField] private int lives;
    [SerializeField] private int highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void AddScore()
    {
        score += 20;
        scoreText.text = "Score: " + score.ToString();
        if (score >= highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    public void DecreaseLives()
    {
        lives--;
        livesText.text = "Lives: " + lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
