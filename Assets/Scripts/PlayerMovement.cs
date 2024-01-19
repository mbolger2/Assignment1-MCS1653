using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Rigidbody of the Player")]
    public Rigidbody2D rb;

    [Header("Speed of the Player")]
    public float speed;

    [Header("Force fo the Jump")]
    public float jumpForce;

    [Header("Jump Charge")]
    public int jumpCharge;

    [Header("Does the Player have the Key?")]
    public bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        jumpCharge = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Handles player movement on the xAxis
        float xMovement;

        xMovement = Input.GetAxis("Horizontal");

        Vector3 motion = new Vector3(xMovement, 0, 0) * speed * Time.deltaTime;
        
        Vector3 finalPos = transform.position + motion;

        transform.position = finalPos;

        // The player can only jump when they have a jump charge
        if (Input.GetButtonDown("Jump") && jumpCharge == 1)
        {
            rb.AddForce(Vector2.up * jumpForce * 100);

            jumpCharge--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player collides with the floor or the conveyor
        // blocks thier jump is reset
        if (collision.gameObject.tag == "Floor" || 
            collision.gameObject.tag == "ConveyorBlock")
        {
            jumpCharge = 1;
        }

        // If the player picks up the key they now
        // have the key and the key despawns
        if (collision.gameObject.tag == "KeyPickup")
        {
            hasKey = true;
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Door" && hasKey)
        {
            SceneManager.LoadScene("winScene");
        }
    }
}
