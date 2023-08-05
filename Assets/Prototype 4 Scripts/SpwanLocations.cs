using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanLocations : MonoBehaviour
{
    public GameObject[] enemyBalls;
    public GameObject[] miniEnemyPrefabs;
    public GameObject bossPrefabs;
    public int bossRound;


    public GameObject[] powerUps;
    private float spwanXD = 6f;
    private float spwanZD = 9f;
    public int enemyCount;
    public int waveNumber;

    void Start()
    {
        SpwanWave(waveNumber);
        int randomPowerup = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[randomPowerup], GenSpwanLocations(), powerUps[randomPowerup].transform.rotation);
        
    }
    private void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            if(waveNumber%bossRound==0)
            {
                SpwanBossWave(waveNumber);
            }
            else
            {
                 SpwanWave(waveNumber);
            }
           
            int randomPowerup = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomPowerup], GenSpwanLocations(), powerUps[randomPowerup].transform.rotation);
        }
    }

    void SpwanWave(int enemyToSpwan)
    {
        for (int i = 0; i <= enemyToSpwan; i++)
        {
            int index = Random.Range(0, enemyBalls.Length);
            Instantiate(enemyBalls[index], GenSpwanLocations(), enemyBalls[index].transform.rotation);
        }
    }

    private Vector3 GenSpwanLocations()
    {
        Vector3 randomPos = new Vector3(Random.Range(-spwanXD, spwanXD), 0.5f, Random.Range(-spwanZD, spwanZD));
        return randomPos;
    }
    public void SpwanMiniEnemy(int amount)
    {
        for(int i=0;i<amount;i++)
        {
            int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
            Instantiate(miniEnemyPrefabs[randomMini], GenSpwanLocations(), miniEnemyPrefabs[randomMini].transform.rotation);

        }
    }
    void SpwanBossWave(int currentRound)
    {
        int miniEnemysToSpwan;
        if(bossRound!=0)
        {
            miniEnemysToSpwan = currentRound / bossRound;
        }
        else
        {
            miniEnemysToSpwan = 1;
        }
        var boss = Instantiate(bossPrefabs, GenSpwanLocations(), bossPrefabs.transform.rotation);
        boss.GetComponent<EnemyController>().miniEnemySpwanCount = miniEnemysToSpwan;

    }
   
}
