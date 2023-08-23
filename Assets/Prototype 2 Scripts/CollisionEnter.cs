using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnter : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip hitClip;

    private GameManager gameManager;

    private void Start()
    {
        audioSource = GameObject.Find("BGMusic").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            gameManager.AddLives(-1);
            audioSource.PlayOneShot(hitClip, 1f);
        }

    }
}
