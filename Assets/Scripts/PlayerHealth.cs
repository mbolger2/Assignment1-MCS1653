using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player's Lives")]
    public int health;
    public int numHearts;

    public Image[] hearts;
    public Sprite heart;

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            health--;
        }
    }
}
