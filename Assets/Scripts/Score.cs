using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField]
    private Player1 player;
    [SerializeField]
    private TMP_Text _scoreText;

    // Update is called once per frame
    void Update()
    {
        UpdateLives();
    }

    public void UpdateLives()
    {
        // UPDATE TEXT 
        float n = player._score;
        _scoreText.text = n.ToString();
    }
}
