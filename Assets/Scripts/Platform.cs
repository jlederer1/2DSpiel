using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        Debug.Log(this.name + " collided with " + other.collider.gameObject.name);
        {
            other.collider.GetComponent<Player1>().SetSpawn(this.transform.position + new Vector3(0f, 1f, 0f));
        }
    }
}
