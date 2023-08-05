using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public ParticleSystem effects;
    public Transform here;
    public GameObject[] foods;
    private float moveSpeed=15f;
    private float xRange=18f;
    private float zRange=26.5f;
    private float zMinRange=13f;

    void FixedUpdate()
    {
        AreaBounding();
        Movement();
        Shooting();
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
            int index = Random.Range(0, foods.Length);
            effects.Play();
            Instantiate(foods[index],here.position, foods[index].transform.rotation);
        }
        else
        {
            effects.Stop();
        }
    }
}
