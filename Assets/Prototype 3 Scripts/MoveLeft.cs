using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15.0f;
    private PlayerMove playerScript;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMove>();
    }
    void FixedUpdate()
    {
        if (playerScript.gameOver == false)
        {
            if (playerScript.dashing == true)
            {
                transform.Translate(Vector3.left * speed * 2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }
}
