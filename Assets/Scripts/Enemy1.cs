using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    [SerializeField]
    private float _enemySpeed = 0.1f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // MOVEMENT
        transform.Translate(Vector2.down * _enemySpeed * Time.deltaTime);

        // TRANPORT BACK TO START
        if(transform.position.y < -10)
        {
            transform.position = new Vector2(Random.Range(-10f, 10f), 20f);
        }
    }
        
}