using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonController : MonoBehaviour
{
    public bool gameOver;
    public float addtionalForce = 7f;
    public float floatForce=6;
    public float yRange;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bumpSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Mouse0) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce,ForceMode.Impulse);
        }

        if(transform.position.y>=yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
            playerRb.AddForce(Vector3.down * addtionalForce,ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }
        
       
        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }
        else if(other.gameObject.CompareTag("Ground"))
        {
            playerRb.AddForce(Vector3.up * addtionalForce,ForceMode.Impulse);
            playerAudio.PlayOneShot(bumpSound,1.0f);
        }
        

    }

}
