using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("The Player")]
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 respawnUpdate;

        if (collision.gameObject.CompareTag("Player"))
        {
            respawnUpdate = new Vector2(transform.position.x, transform.position.y);

            player.GetComponent<PlayerMovement>().respawnPoint = respawnUpdate;
        }
    }
}
