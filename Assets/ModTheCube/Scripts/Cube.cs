using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float speed = 100f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = Vector3.one * 1.2f;
    }
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 10.0f * Time.deltaTime, 10.0f * Time.deltaTime);

        Material material = Renderer.material;

        material.color = new Color(Random.Range(10, 255), Random.Range(10, 255), Random.Range(10, 255), 255) * Time.deltaTime;
    }
}
