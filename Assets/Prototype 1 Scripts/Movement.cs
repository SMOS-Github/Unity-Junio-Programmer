using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public List<WheelCollider> allWheels;
    private Rigidbody playerRigidbody;
    public GameObject centerOfMass;
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey;
    public Text speedText;
    public Text rpmText;
    public float speed;
    public float rpm;

    private float vanSpeed=51000f;
    private float vanRotation=100f;
    private int wheelsOnGrounded;
   
  
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.centerOfMass = centerOfMass.transform.position;
    }

    void FixedUpdate()
    {

        if(isGrounded())
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * horizontal * vanRotation * Time.deltaTime);
            playerRigidbody.AddRelativeForce(Vector3.forward * vertical * vanSpeed);

            speed = Mathf.Round(playerRigidbody.velocity.magnitude * 2.237f);
            speedText.text = "Speed :" + speed + "Mph";
            rpm = Mathf.Round((speed) * 30);
            rpmText.text = "RPM :" + rpm;



            if (Input.GetKeyDown(switchKey))
            {
                mainCamera.enabled = !mainCamera.enabled;
                hoodCamera.enabled = !hoodCamera.enabled;
            }
        }

    }
   
    bool isGrounded()
    {
        wheelsOnGrounded = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGrounded++;
            }

        }
        if(wheelsOnGrounded==4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   
}
