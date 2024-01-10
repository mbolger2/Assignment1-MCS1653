using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Rigidbody of the Player")]
    public Rigidbody2D rb;

    [Header("Speed of the Player")]
    public float speed;

    [Header("Force fo the Jump")]
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
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


        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce * 100);
        }
    }
}
