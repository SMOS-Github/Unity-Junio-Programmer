using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float mouseSensitivity;

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * horizontal * mouseSensitivity * Time.deltaTime,Space.World);
    }
}
