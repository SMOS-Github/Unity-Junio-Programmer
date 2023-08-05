using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRb;
    public GameObject player;
    public float speed=100f;
    public float yRange = -30f;

    public bool isBoss = false;
    public float spwanInterval;
    private float nextSpwan;
    public int miniEnemySpwanCount;
    private SpwanLocations spwanLocations;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        if(isBoss)
        {
            spwanLocations = FindObjectOfType<SpwanLocations>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirecation = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirecation * speed * Time.deltaTime);

        if (transform.position.y <= yRange)
        {
            Destroy(gameObject);
        }
        if(isBoss)
        {
            if(Time.time>nextSpwan)
            {
                nextSpwan = Time.time + spwanInterval;
                spwanLocations.SpwanMiniEnemy(miniEnemySpwanCount);
            }
        }
    }
}
