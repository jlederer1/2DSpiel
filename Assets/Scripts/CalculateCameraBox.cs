using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=OXqZ4FOwGYg 

public class CalculateCameraBox : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField] 
    private BoxCollider2D camBox; 
    private float sizeX, sizeY, ratio; 

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CalculateCameraBox: Start");
        cam = GetComponent<Camera>();
        camBox = GetComponent<BoxCollider2D>();        
        sizeY = cam.orthographicSize * 2; 
        ratio = (float)Screen.width/(float)Screen.height;      
        sizeX = sizeY * ratio; 
        camBox.size = new Vector2(sizeX, sizeY);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
