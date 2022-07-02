using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ESpawnManager : MonoBehaviour
{
    //// (COPIED) ////

    // VARIABLES
    [SerializeField]
    private GameObject _enemy1Prefab;

    [SerializeField]
    private float _delay = 2f;
    private bool _alive = true;

    ////  (NEW)  ////

    [SerializeField]
    private float spawn_x_low = -10f;
    [SerializeField]
    private float spawn_x_up = 10f;
    [SerializeField]
    private float spawn_y = 10f;

    private Vector2 player_pos;
    private string player_name = "Player1";
    private Vector2 spawn_vec = new Vector2(0,2);

    void Start()
    {
        StartCoroutine(SpawnSystem());
    }


    public void onPlayerDeath()
    {
        _alive = false;
    }

    IEnumerator SpawnSystem()
    {
        // SPAWNING
        while (_alive)
        {
            Instantiate(_enemy1Prefab, spawn_vec, Quaternion.identity, this.transform);
            yield return new WaitForSeconds(_delay);
            Update_SpawnSystem();
        }

        yield return null;
    } 

    public void Update_SpawnSystem()
    {
        player_pos = GameObject.Find(player_name).transform.position; 
        spawn_vec = player_pos + new Vector2(Random.Range(spawn_x_low, spawn_x_up), spawn_y);
    }
}