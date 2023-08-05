using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniMoveForward : MonoBehaviour
{
    [SerializeField]private float speed;
    
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}

