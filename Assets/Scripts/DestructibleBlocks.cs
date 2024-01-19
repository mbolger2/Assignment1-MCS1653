using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBlocks : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
