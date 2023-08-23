using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private AudioSource audioSource;
    public ParticleSystem effects;
    public AudioClip throwSound;

    public Transform here;
    public GameObject[] foods;

    private GameManager gameManager;
    private float moveSpeed = 15f;
    private float xRange = 18f;
    private float zRange = 26.5f;
    private float zMinRange = 13f;


    private void Start()
    {
        audioSource = GameObject.Find("BGMusic").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {

        if (gameManager.gameOver == false)
        {
            Movement();
            Shooting();
        }
        AreaBounding();
    }
    void AreaBounding()
    {
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        if (transform.position.z < -zMinRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zMinRange);
        }
    }
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticallInput).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource.PlayOneShot(throwSound, 1f);
            int index = Random.Range(0, foods.Length);
            effects.Play();
            Instantiate(foods[index], here.position, foods[index].transform.rotation);
        }
        else
        {
            effects.Stop();
        }
    }
}
