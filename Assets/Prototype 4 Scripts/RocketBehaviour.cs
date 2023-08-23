using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RocketBehaviour : MonoBehaviour
{
    private Transform target;
    private float speed=15f;
    private bool homing;

    private float rocketStrength=15f;
    private float aliveTimer=1.5f;

    void FixedUpdate()
    {
        if(homing && target!=null)
        {
            Vector3 moveDirecatation = (target.transform.position - transform.position).normalized;
            transform.position += moveDirecatation * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    }
    public void Fire(Transform newTarget)
    {
        target = newTarget;
        homing = true;
        Destroy(gameObject, aliveTimer);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(target!=null)
        {
            if(collision.gameObject.CompareTag(target.tag))
            {
                Rigidbody targetRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -collision.contacts[0].normal;
                targetRb.AddForce(away * rocketStrength, ForceMode.Impulse);
                Destroy(gameObject);
            }
        }
    }
}
