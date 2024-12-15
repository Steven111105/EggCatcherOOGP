using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text scoreText;
    public void ShowGameOver(int score){
        Time.timeScale = 0;
        transform.gameObject.SetActive(true);
        scoreText.text = "Score: " + score;
        if(score > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", score);
        }
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
    public void Retry(){
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu(){
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
