using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    // VARIABLES
    private float length;
    // public GameObject cam;
    [SerializeField]
    private float backgroundSpeed;

    // Start is called before the first frame update
    void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * backgroundSpeed * Time.deltaTime);
        if (transform.position.x > length)
        {
            transform.Translate(Vector2.left * length * 2);
        }
    }
}
