using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{   
    // VARIABLES 

    // -Movement
    [SerializeField]
    private Rigidbody2D RB;
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _jumpingSpeed = 10f;

    // -Jumping with time delay 
    private bool doubleJump;
    [SerializeField]
    private float _coolDownTime = 1f;
    private float _nextJumpTime = 0f;

    // -Teleport
    private float low_border = -20f;

    // -UI with Lifebar and height score
    [SerializeField]
    public int _lives;
    private int _maxLives;
    public HealthBar healthBar;
    public float _score;

    // -Spawnmanager to trigger deconstruction 
    [SerializeField]
    private GameObject _spawnManager;

    // -Item
    [SerializeField]
    private int woolBonus = 3;
    [SerializeField]
    private Vector3 spawn_vec; 

   
    void Start()
    {
        // START POSITION 
        spawn_vec = new Vector2(-1f, 1f);
        transform.position = spawn_vec;
        // Enable double jump 
        doubleJump = true;

        // Init lives, healthbar and height score of the player 
        _maxLives = 9;
        _lives = _maxLives;
        healthBar.setMaxHealth(_maxLives);
        _score = transform.position.y;

        // INIT RIGIDBODY 
        RB = GetComponent<Rigidbody2D>();
        if (RB == null)
        {
            Debug.LogError("Player1 is missing a Rigidbody2D component");
        }

    }

    void Update()
    {
        ScoreUpdate(); 
        PlayerMovement();
    }

    void ScoreUpdate()
    {
        // if highscore beaten:
        if (_score < transform.position.y)
        {   // update score 
            _score = transform.position.y;
        }
    }

    void PlayerMovement()
    {
        // MOVEMENT
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * _speed * horizontalInput);

        // JUMPING
        if (Input.GetKeyDown("space") && _nextJumpTime < Time.time)
        {
            // If double jump is currently disabled (cooldown):
            if (!doubleJump)
            {
                doubleJump = true;
                RB.velocity += new Vector2(0f, _jumpingSpeed);
                _nextJumpTime = Time.time + _coolDownTime;  
            } 
            // If double jump is currently enabled:
            else if (doubleJump)
            { 
                doubleJump = false;
                RB.velocity += new Vector2(0f, _jumpingSpeed);
            }
        }

        // TELEPORT - if player is falling teleport him back to a certain position
        if (transform.position.y < low_border)
        {
            // Extra damage 
            Damage();
            Damage();
            Damage();
            // Teleport
            transform.position = spawn_vec;
        }

    }

    public void Damage()
    {
        // Update health bar
        _lives --;
        Debug.Log("HEARTS -1");
        healthBar.setHealth(_lives);
        
        // DEATH 
        if (_lives == 0)
        {
            Debug.Log(this.name + "damaged: Death");

            // DELETE ENEMYS IN HIERACHY
            foreach (Transform child in _spawnManager.transform)
            {
                Destroy(child.gameObject);
            }

            // STOP SPAWNING
            if (_spawnManager != null)
            {
                _spawnManager.GetComponent<ESpawnManager>().onPlayerDeath();
            }
            else
            {
                Debug.LogError("Spawn_Manager not assigned.");
            }

            // Destroy Player
            Destroy(this.gameObject);
        }
    }

    // Triggered when item picked up
    public void Wolle()
    {
        // Save old value 
        int lives = _lives;
        int received = 0;
        // Add 3 lives (max 9 lives) 
        // If less than 3 hearts are needed:
        if (_lives < (9 - woolBonus))
        {
            _lives += woolBonus;
            received = 3;
        }
        // If 3 lives are needed:
        else 
        {
            _lives = 9;
            received = _lives - lives;
        }
        Debug.Log("HEARTS +" + received);
    }

    public void SetSpawn(Vector3 vec)
    {
        Debug.Log(this.name + ": SetSpawn()");
        spawn_vec = vec;
    }
}
