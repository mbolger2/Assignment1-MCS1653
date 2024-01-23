using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // The images that will appear on screen
    [Header("Heart Images")]
    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;

    [Header("The Players GameObject")]
    public GameObject player;

    // The health counter
    public int health;

    void Update()
    {
        // Switch statment handles what hearts are appearing on screen
        switch (health)
        {
            case 0:
                {
                    health1.gameObject.SetActive(false); 
                    health2.gameObject.SetActive(false);
                    health3.gameObject.SetActive(false);
                    health4.gameObject.SetActive(false);
                    SceneManager.LoadScene("gameOver");
                    break;
                }
            case 1:
                {
                    health1.gameObject.SetActive(true);
                    health2.gameObject.SetActive(false);
                    health3.gameObject.SetActive(false);
                    health4.gameObject.SetActive(false);
                    break;
                }
            case 2:
                {
                    health1.gameObject.SetActive(true);
                    health2.gameObject.SetActive(true);
                    health3.gameObject.SetActive(false);
                    health4.gameObject.SetActive(false);
                    break;
                }
            case 3:
                {
                    health1.gameObject.SetActive(true);
                    health2.gameObject.SetActive(true);
                    health3.gameObject.SetActive(true);
                    health4.gameObject.SetActive(false);
                    break;
                }
            case 4:
                {
                    health1.gameObject.SetActive(true);
                    health2.gameObject.SetActive(true);
                    health3.gameObject.SetActive(true);
                    health4.gameObject.SetActive(true);
                    break;
                }

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spikes")
        {
            health--;
        }

        if (other.gameObject.tag == "HealthPickup")
        {
            health++;
            other.gameObject.SetActive(false);
        }
    }
}