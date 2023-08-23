using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip eatSound;

    private GameManager gameManager;

    private void Start()
    {
        audioSource = GameObject.Find("BGMusic").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            gameManager.AddScores(5);
            audioSource.PlayOneShot(eatSound, 1f);
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            gameManager.AddLives(-1);
        }
        if(other.gameObject.CompareTag("Red Wall"))
        {
            Destroy(gameObject);
        }
    }
}
