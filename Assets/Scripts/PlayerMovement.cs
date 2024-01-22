using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    [Header("Key Image")]
    public GameObject keyImage;

    [Header("Particle System")]
    public ParticleSystem dustPS;

    [Header("Jump Audio")]
    public AudioClip jumpSound;
    public AudioSource jumpSoundSource;

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
            PlayAudio();
            CreateDust();
        }

        // Handles the key inventory
        if (hasKey)
        {
            keyImage.gameObject.SetActive(true);
        }
        else
        {
            keyImage.gameObject.SetActive(false);
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player picks up the key they now
        // have the key and the key despawns
        if (collision.gameObject.tag == "KeyPickup")
        {
            hasKey = true;
            collision.gameObject.SetActive(false);
        }

        // The player has the key and enters the ending door
        if (collision.gameObject.tag == "Door" && hasKey)
        {
            SceneManager.LoadScene("winMenu");
        }
    }

    // Plays the particle system
    void CreateDust()
    {
        dustPS.Play();
    }

    // Plays the audio clip
    void PlayAudio()
    {
        jumpSoundSource.PlayOneShot(jumpSound);
    }
}
