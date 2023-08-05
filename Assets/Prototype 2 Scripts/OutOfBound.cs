using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            gameManager.AddScores(5);
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            gameManager.AddLives(-1);
        }
    }
}
