using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    public float destroyRate=2.5f;
    void Start()
    {
        Destroy(gameObject, destroyRate); // destroy particle after 2 seconds
    }


}
