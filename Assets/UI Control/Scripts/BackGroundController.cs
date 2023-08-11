using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private Vector3 spwanPosition;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        spwanPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<spwanPosition.x-repeatWidth)
        {
            transform.position = spwanPosition;
        }
    }
}
