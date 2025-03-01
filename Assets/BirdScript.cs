using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public bool gameHasStarted = false;

    public AudioSource audioSource;
    public AudioClip flapSound; 
    public AudioClip gameOverSound; 

    private bool gameOverSoundPlayed = false;

    public float tiltUpAngle = 30f;
    public float tiltDownAngle = -90f;
    public float smoothTilt = 5f;

    private Quaternion targetRotation;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioSource = GetComponent<AudioSource>(); 
        targetRotation = transform.rotation;
    }

    void Update()
    {
        if (gameHasStarted && Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            audioSource.PlayOneShot(flapSound); 
            targetRotation = Quaternion.Euler(0, 0, tiltUpAngle);  
        }

        if (transform.position.y > Camera.main.orthographicSize || transform.position.y < -Camera.main.orthographicSize)
        {
            if (!gameOverSoundPlayed) 
            {
                gameOver();
                audioSource.PlayOneShot(gameOverSound); 
                gameOverSoundPlayed = true; 
            }
        }

        if (myRigidbody.linearVelocity.y < 0)
        {
            targetRotation = Quaternion.Euler(0, 0, tiltDownAngle); 
        }
        else if (myRigidbody.linearVelocity.y > 0)
        {
            targetRotation = Quaternion.Euler(0, 0, tiltUpAngle); 
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothTilt);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameOverSoundPlayed) 
        {
            logic.gameOver();
            audioSource.PlayOneShot(gameOverSound);
            gameOverSoundPlayed = true; 
        }
        birdIsAlive = false;
    }

    void gameOver()
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
