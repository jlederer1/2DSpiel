using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    // VARIABLES 
    private new SpriteRenderer renderer;
    [SerializeField]
    private Player1 player;

    void Start()
    {
        // Get the Border Renderer to controll color
        renderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        // Update color according to Player's lifebar (from green(full) to red(dead))
        //Debug.Log(this.name + ": Update() setting color");
        renderer.color = Color.green/9*player._lives + Color.red/9*(9-player._lives);
    }
}
