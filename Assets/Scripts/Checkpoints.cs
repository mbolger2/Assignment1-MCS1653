using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public GameObject spawnPoint;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Spikes")
        {
            this.transform.position = spawnPoint.transform.position;
        }

        if (col.transform.tag == "Checkpoint")
        {
            spawnPoint.transform.position = col.transform.position;
        }
    }
}