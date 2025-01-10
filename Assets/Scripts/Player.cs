using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float movement;
    public float playerSpeed;
    [SerializeField] TMP_Text scoreText;
    int score;
    [SerializeField] TMP_Text lifeText;
    [SerializeField] int life;
    [SerializeField] GameOverScript gameOverScript;
    PlayerSFX playerSFX;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverScript.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        playerSFX = GetComponent<PlayerSFX>();
        life = 3;
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(movement * playerSpeed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");   
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("trigger enter");
        if(other.CompareTag("Egg")){
            Destroy(other.gameObject);
            playerSFX.PlayEggSFX();
            score++;
            scoreText.text = "Score: " + score;
        }else if(other.CompareTag("Bomb")){
            Destroy(other.gameObject);
            playerSFX.PlayBombSFX();
            life--;
            lifeText.text = "Life: " + life;
            if(life == 0){
                GameOver();
            }
        }
    }

    void GameOver(){
        // Debug.Log("Game Over");
        gameOverScript.ShowGameOver(score);
    }
}
