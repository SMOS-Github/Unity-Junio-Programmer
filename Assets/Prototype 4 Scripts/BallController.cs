using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public powerUpType currentPowerUp = powerUpType.None;

    public GameObject rocketPrefab;
    public GameObject tmpRocket;
    private Coroutine powerUpCountdown;
    private Rigidbody rb;
    private GameObject focalPoint;
    public ParticleSystem powerUpIndicatator;

    public bool hasPowerUp;
    private float moveSpeed = 300f;
    private float yRange = -30f;
    public float gravityModifier = 1f;

    public float hangTime=5;
    public float smashSpeed=50;
    public float explosionForce=150;
    public float explosionRadius=5;

    private bool smashing = false;
    private float floor;


    private Vector3 offset = new Vector3(0, -0.15f, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward *vertical * moveSpeed * Time.deltaTime);
        powerUpIndicatator.transform.position = transform.position + offset;
        if (transform.position.y <= yRange)
        {
            Destroy(gameObject);
        }

        if(currentPowerUp==powerUpType.Rockets&&Input.GetKeyDown(KeyCode.F))
        {
            LaunchRockets();
        }
        if(currentPowerUp==powerUpType.Smashh &&Input.GetKeyDown(KeyCode.Space)&&!smashing)
        {
            smashing = true;
            StartCoroutine(Smashed());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            currentPowerUp = other.gameObject.GetComponent<PowerUp>().powerUpType;
            powerUpIndicatator.Play();
            Destroy(other.gameObject);

            if(powerUpCountdown!=null)
            {
                StopCoroutine(powerUpCountdown);
            }

            powerUpCountdown= StartCoroutine(CoolDown(6));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && currentPowerUp==powerUpType.PushBack)
        {
            float powerStrength = 20f;
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = enemyRigidBody.transform.position - transform.position;
            enemyRigidBody.AddForce(awayFromPlayer * powerStrength, ForceMode.Impulse);
        }
    }

    void LaunchRockets()
    {
        foreach(var enemy in FindObjectsOfType<EnemyController>())
        {
            tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
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
        var enemys = FindObjectsOfType<EnemyController>();
        floor = transform.position.y;

        float jumpTime = Time.time + hangTime;
        while(Time.time<jumpTime)
        {
            rb.velocity = new Vector2(rb.velocity.x, smashSpeed);
            yield return null;
        }
        while(transform.position.y>floor)
        {
            rb.velocity = new Vector2(rb.velocity.x, -smashSpeed * 2);
            yield return null;
        }
        for(int i=0;i<enemys.Length;i++)
        {
            if(enemys[i]!=null)
            {
                enemys[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius, 5.0f, ForceMode.Impulse);
            }
            smashing = false;
        }
    }
}
