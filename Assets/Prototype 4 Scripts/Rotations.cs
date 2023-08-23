using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rotations : MonoBehaviour
{
    private float speed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
