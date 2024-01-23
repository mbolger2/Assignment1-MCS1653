using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundConveyors : MonoBehaviour
{
    [Header("Barrel Transform")]
    public Transform barrelTransform;

    float time;

    public float deSpawnTime;

    // Temporary vector to handle player movement
    private Vector2 temp;

    // Calls every frame the player is in contact with a conveyor
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ConveyorBlock")
        {
            // Get the players transform
            temp = barrelTransform.position;

            // Add 0.1 in the x direction
            temp.x += 0.1f;

            // Set the players transform to the new transform
            barrelTransform.position = temp;
        }
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= deSpawnTime)
        {
            this.gameObject.SetActive(false);

            time = 0.0f;
        }
    }
}
