using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public powerUpType currentPowerUp = powerUpType.None;

    public ParticleSystem powerUpIndicatator;
    private Coroutine powerUpCountdown;
    public GameObject rocketPrefab;
    private GameObject focalPoint;
    public GameObject tmpRocket;
    private Rigidbody rb;
    public GameObject restartBT;
    private Vector3 offset = new Vector3(0, -0.15f, 0);

    private bool hasPowerUp = false;
    private float moveSpeed = 500f;
    private float yRange = -30f;
    private float gravityModifier = 1.5f;

    private float hangTime = 0.2f;
    private float smashSpeed = 30;
    private float explosionForce = 8;
    private float explosionRadius = 200;

    private bool smashing = false;
    private float floorY;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * vertical * moveSpeed * Time.deltaTime);
        powerUpIndicatator.transform.position = transform.position + offset;


        if (currentPowerUp == powerUpType.Rockets && Input.GetKeyDown(KeyCode.F))
        {
            LaunchRockets();
        }
        if (currentPowerUp == powerUpType.Smashh && Input.GetKeyDown(KeyCode.Space) && !smashing)
        {
            smashing = true;
            StartCoroutine(Smashed());
        }

        if(transform.position.y<-15)
        {
            restartBT.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Debug.Log(hasPowerUp);
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            powerUpIndicatator.Play();
            Destroy(other.gameObject);

            if (powerUpCountdown != null)
            {
                StopCoroutine(powerUpCountdown);
            }

            powerUpCountdown = StartCoroutine(CoolDown(6));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && currentPowerUp == powerUpType.PushBack)
        {
            float powerStrength = 20f;
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = enemyRigidBody.transform.position - transform.position;
            enemyRigidBody.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
        
    }

    void LaunchRockets()
    {
        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);//i change quartinion.identity to transform.rotation
            tmpRocket.GetComponent<RocketBehaviour>().Fire(enemy.transform);
        }
    }

    IEnumerator CoolDown(float time)
    {
        yield return new WaitForSeconds(time);
        hasPowerUp = false;
        currentPowerUp = powerUpType.None;
        powerUpIndicatator.Stop();
    }
    IEnumerator Smashed()
    {
        var Enemys = FindObjectsOfType<Enemy>();
        floorY = transform.position.y;

        float jumpTime = Time.time + hangTime;
        while (Time.time < jumpTime)
        {
            rb.velocity = new Vector2(rb.velocity.x, smashSpeed);
            yield return null;
        }
        while (transform.position.y > floorY)
        {
            rb.velocity = new Vector2(rb.velocity.x, -smashSpeed * 2);
            yield return null;
        }
        for (int i = 0; i < Enemys.Length; i++)
        {
            if (Enemys[i] != null)
            {
                Enemys[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
            }

        }
        smashing = false;
    }
}
