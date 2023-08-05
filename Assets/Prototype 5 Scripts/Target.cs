using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameHandeler gameHandeler;
    public ParticleSystem effects;

    public float minForce;
    public float maxForce;
    public float maxTorque;
    public float xRange;
    public float yRange;
    public int points;

    void Start()
    {
        gameHandeler = GameObject.Find("Game Handeler").GetComponent<GameHandeler>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(TorqueForce(), ForceMode.Impulse);
        targetRb.AddTorque(SpwanRange(), SpwanRange(), SpwanRange());
        transform.position = SpwanPosition();
    }

    Vector3 TorqueForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }
    float SpwanRange()
    {
        return Random.Range(-maxForce, maxTorque);
    }
    Vector3 SpwanPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), -yRange);
    }

    private void OnMouseDown()
    {
        if (gameHandeler.gameOver == false&&gameHandeler.paused==false)
        {
            if (gameObject.CompareTag("Bad"))
            {
                Instantiate(effects, transform.position, effects.transform.rotation);
                gameHandeler.UpdateScore(points);
                gameHandeler.UpdateLives(-1);
                Destroy(gameObject);
            }
            else if (gameObject.CompareTag("Good"))
            {
                Instantiate(effects, transform.position, effects.transform.rotation);
                gameHandeler.UpdateScore(points);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (gameObject.CompareTag("Good"))
        {
            gameHandeler.UpdateLives(-1);
        }

    }
    public void DestroyTheTarget()
    {
        if (gameHandeler.gameIsActive == true && gameHandeler.paused == false && gameHandeler.gameOver == false && gameObject.CompareTag("Good"))
        {
            Destroy(gameObject);
            Instantiate(effects, transform.position, effects.transform.rotation);
            gameHandeler.UpdateScore(points);
        }
        if (gameHandeler.gameIsActive == true && gameHandeler.paused == false && gameHandeler.gameOver == false&&gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            Instantiate(effects, transform.position, effects.transform.rotation);
            gameHandeler.UpdateLives(-1);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        gameHandeler.UpdateScore(1);
    }
}
