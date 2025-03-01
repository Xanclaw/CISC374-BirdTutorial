using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class LogicScript : MonoBehaviour
{
    public int playerScore;
public int highScore;
public Text scoreText;
public Text highScoreText;
public GameObject gameOverScreen;
public AudioSource audioSource;
public AudioClip scoreUpSound;

void Start()
{
    highScore = PlayerPrefs.GetInt("HighScore", 0);
    updateHighScoreUI();
    audioSource = GetComponent<AudioSource>();
}

[ContextMenu("Increase Score")]
public void addScore(int scoreToAdd)
{
    playerScore += scoreToAdd;
    scoreText.text = playerScore.ToString();

    audioSource.PlayOneShot(scoreUpSound);

    if (playerScore > highScore)
    {
        highScore = playerScore;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
        updateHighScoreUI();
    }
}

public void gameOver()
{
    gameOverScreen.SetActive(true);
}


private void updateHighScoreUI()
{
    highScoreText.text = "High Score: " + highScore.ToString();
}

public void restartGame()
{
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

}
