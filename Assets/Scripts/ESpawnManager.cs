using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ESpawnManager : MonoBehaviour
{
    // VARIABLES

    // Prefabs
    [SerializeField]
    private GameObject _enemy1Prefab;
    [SerializeField]
    private GameObject _level1_prefab;
    [SerializeField]
    private GameObject _level2_prefab;
    [SerializeField]
    private GameObject _level1_item_prefab;
    
    // Essentials 
    private bool _alive = true;
    private Vector2 player_pos;

    // Vars to build drops/enemies
    private float _delay = 1f;
    [SerializeField]
    private float spawn_x_low = -10f;
    [SerializeField]
    private float spawn_x_up = 10f;
    [SerializeField]
    private float spawn_y = 10f;
    private Vector2 spawn_vec = new Vector2(0,2);
    private string player_name = "Player1";

    // Vars to buil levels
    private int level = 1; 
    [SerializeField]
    private Transform level1;

    void Start()
    {
        StartCoroutine(SpawnSystem());
    }

    IEnumerator SpawnSystem()
    {
        // SPAWNING
        while (_alive)
        {
            Instantiate(_enemy1Prefab, spawn_vec, Quaternion.identity, this.transform);
            Update_SpawnSystem();

            // Spawn new field every 4 unit
            if ((player_pos.y + 1f) / 4f > level)
            {
                // even case
                if (level % 2 == 1)
                {
                    Instantiate(_level1_prefab, level1.position + new Vector3(0f, level*8f, 0f), Quaternion.identity, this.transform);
                    Instantiate(_level1_item_prefab, new Vector3(-4.7f, level*8f + 2.23f, 0f), Quaternion.identity, this.transform);
                }
                // uneven case
                else if (level % 2 == 0)
                {
                    Instantiate(_level2_prefab, level1.position + new Vector3(0f, level*8f, 0f), Quaternion.identity, this.transform);
                }
                level += 1;
            }

            yield return new WaitForSeconds(_delay);
        }
        yield return null;
    } 

    public void Update_SpawnSystem()
    {
        // If Player there, update spawn vector:
        if (GameObject.Find(player_name) != null)
        {
            player_pos = GameObject.Find(player_name).transform.position; 
            spawn_vec = player_pos + new Vector2(Random.Range(spawn_x_low, spawn_x_up), spawn_y);
        }
    }

    public void onPlayerDeath()
    {
        _alive = false;
    }
}