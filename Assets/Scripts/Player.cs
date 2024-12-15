using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    float movement;
    public float playerSpeed;
    int life;
    [SerializeField] TMP_Text scoreText;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        Debug.Log("trigger enter");
        if(other.CompareTag("Egg")){
            Destroy(other.gameObject);
            score++;
            scoreText.text = "Score: " + score;
        }else if(other.CompareTag("Bomb")){
            Destroy(other.gameObject);
            life--;
            GameOver();
        }
    }

    void GameOver(){
        Debug.Log("Game Over");
    }
}
