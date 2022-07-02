using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolle : MonoBehaviour
{
    public float speed;
    // public float rayDist;
    // private bool movingRight;
    public Transform groundDetect;

    public Rigidbody2D rb; 
    public bool mustPatrol; 
    private bool mustFlip; 
    public LayerMask groundLayer; 

    // Start is called before the first frame update
    void Start() 
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector2.right * speed * Time.deltaTime);
        // RaycastHit2D groundCheck = Physics2D.Raycast(groundDetect.position, Vector2.down, rayDist); 

        // if (groundCheck.collider == false)
        // {
        //     if(movingRight)
        //     {
        //         transform.eulerAngles = new Vector2(0, -180);
        //         movingRight = false;
        //     }
        //     else
        //     {
        //         transform.eulerAngles = new Vector2(0, 0);
        //         movingRight = true;
        //     }
        // }

        if (mustPatrol) 
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol) 
        {
            mustFlip = !Physics2D.OverlapCircle(groundDetect.position, 0.1f, groundLayer);
        }
    }

    void Patrol() 
    {
        if (mustFlip) {Flip();}
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    }

    void Flip() 
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        mustPatrol = true; 
    }
}
