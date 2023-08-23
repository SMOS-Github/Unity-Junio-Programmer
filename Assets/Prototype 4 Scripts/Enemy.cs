using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRigidbody;
    private GameObject player;
    public float speed = 100f;

    //Adding Boss Feature.
    private bool isBoss = false;
    private bool gameOver = false;
    private float spawnInterval = 3.0f;
    private float nextSpawn;
    public int miniEnemySpawnCount;
    private SpwanLocations spawnManager;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        if (isBoss)
        {
            spawnManager = FindObjectOfType<SpwanLocations>();
        }
    }

    void Update()
    {
        Vector3 lookDirecation = (player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(lookDirecation * speed * Time.deltaTime);

        if (isBoss)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnInterval;
                spawnManager.SpawnMiniEnemy(miniEnemySpawnCount);
            }

        }
        if(transform.position.y<-10)
        {
            Destroy(gameObject);
        }
    }
   
}
