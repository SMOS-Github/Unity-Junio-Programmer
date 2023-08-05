using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeating : MonoBehaviour
{
    private float speed = 20f;
    private Vector3 startPos;
    private float repeateWidth;
    private PlayerMove playerScript;

    void Awake()
    {
        startPos = transform.position;
        repeateWidth = GetComponent<BoxCollider>().size.x / 2;
        playerScript = GameObject.Find("Player").GetComponent<PlayerMove>();

    }
    void Update()
    {
        if (transform.position.x < startPos.x - repeateWidth)
        {
            transform.position = startPos;
        }

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
