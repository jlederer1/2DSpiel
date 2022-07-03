using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolle : MonoBehaviour
{
    // VARIABLES

    // Moving
    public Rigidbody2D rb; 
    public float speed;

    // Bools to control patroll and direction 
    public bool mustPatrol; 
    private bool mustFlip; 

    // Detection Object attached to wool instance
    public Transform groundDetect;
    public LayerMask groundLayer; 

    void Start() 
    {
        mustPatrol = true;
    }

    void Update()
    {
        if (mustPatrol) 
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol) 
        {
            // G roundDetect changes bool mustFlip, if end of wool's platform is reached 
            mustFlip = !Physics2D.OverlapCircle(groundDetect.position, 0.1f, groundLayer);
        }
    }

    void Patrol() 
    {
        // Occasionally flip
        if (mustFlip) {Flip();}
        // Move rigidbody
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    }

    void Flip() 
    {
        // Pause patrol, flip sprite, invert speed
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            // Trigger Player's Wolle() function
            other.GetComponent<Player1>().Wolle();
            Destroy(this.gameObject);
            Debug.Log("YOU GAINED WOOL: HEARTS +3!");
        }
    }
}
