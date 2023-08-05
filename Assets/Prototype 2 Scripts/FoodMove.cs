using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMove : MonoBehaviour
{
    private float speed=45;

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);    
    }
}
