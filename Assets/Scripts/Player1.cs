using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{   
    // VARIABLES
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _jumpingSpeed = 10f;

    [SerializeField]
    private Rigidbody2D RB;
    
    // Jumping, time delay 
    private bool doubleJump;
    [SerializeField]
    private float _coolDownTime = 1f;
    private float _nextJumpTime = 0f;
    // teleport
    private float low_border = -20f;

    // Start is called before the first frame update
    void Start()
    {
        // START POSITION 
        transform.position = new Vector2(0f, 1f);
        doubleJump = true;

        // INIT RIGIDBODY 
        RB = GetComponent<Rigidbody2D>();
        if (RB == null)
        {
            Debug.LogError("Player1 is missing a Rigidbody2D component");
        }

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        // MOVEMENT
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * _speed * horizontalInput);

        // JUMPING
        if (Input.GetKeyDown("space") && _nextJumpTime < Time.time)
        {
            if (!doubleJump)
            {
                doubleJump = true;
                if (Time.time - _nextJumpTime < _coolDownTime)
                {
                    RB.velocity += new Vector2(0f, _jumpingSpeed/2); 
                } 
                else 
                {
                    RB.velocity += new Vector2(0f, _jumpingSpeed);
                }
                _nextJumpTime = Time.time + _coolDownTime;  
            } 
            else if (doubleJump)
            { 
                doubleJump = false;
                RB.velocity += new Vector2(0f, _jumpingSpeed);
                _nextJumpTime = Time.time + (_coolDownTime / 10);
            }
        }

        // TELEPORT - if player is falling teleport him back to a certain position
        if (transform.position.y < low_border)
        {
            transform.position = new Vector3(0f, 1f);
        }

    }
    
    
}
