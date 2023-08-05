using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManagerSC : MonoBehaviour
{
    public GameObject[] obstPrefab;
    private float timing=3.0f;
    private float repaeatTime=2.5f;
    private PlayerMove playerScript;

    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMove>();
        InvokeRepeating("SpwanPosition", timing, repaeatTime);
    }

    void SpwanPosition()
    {
        int index = Random.Range(0, obstPrefab.Length);
        Vector3 spwanPos = new Vector3(35, 0, 0);

        if (playerScript.gameOver==false)
        {
            Instantiate(obstPrefab[index], spwanPos, obstPrefab[index].transform.rotation);
        }
    }
}
