using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    [Header("GameObjects Arrays")]
    public GameObject[] animals;

    private float xRange = -20f;
    private float xRangeP = 18f;
    private float zRange=40f;
    private float zRangeP=-3f;

    private float xRangeL=35f;
    private float zRangeL=25f;
    private float zRangeLP=-18f;

    private float xRangeR=-35f;
    private float zRangeR=25f;
    private float zRangeRP=-10f;

    private float atTime=2.5f;
    private float atTimeL=5.5f;
    private float atTimeR=7f;

    private float repeatRate=1.5f;
    private float repeatRateL=2.5f;
    private float repeatRateR=3.5f;
    

    void Start()
    {
        InvokeRepeating("SpwanPos", atTime, repeatRate);
        InvokeRepeating("LeftSpwan", atTimeL, repeatRateL);
        InvokeRepeating("RightSpwan", atTimeR, repeatRateR);

    }

    void SpwanPos()
    {
        int index = Random.Range(0, animals.Length);
        Vector3 spwanPos = new Vector3(Random.Range(xRange, xRangeP), 0, Random.Range(zRange,zRangeP));
        Instantiate(animals[index], spwanPos, animals[index].transform.rotation);
    }
    
    void LeftSpwan()
    {
        int index = Random.Range(0, animals.Length-4);
        Vector3 spwanPos = new Vector3(Random.Range(xRangeL,xRangeL),0,Random.Range(zRangeL,zRangeLP));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animals[index], spwanPos, Quaternion.Euler(rotation));
    }
    void RightSpwan()
    {
        int index = Random.Range(0, animals.Length-4);
        Vector3 spwanPos = new Vector3(Random.Range(xRangeR,xRangeR),0,Random.Range(zRangeR,zRangeRP));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(animals[index], spwanPos, Quaternion.Euler(rotation));
    }
}

