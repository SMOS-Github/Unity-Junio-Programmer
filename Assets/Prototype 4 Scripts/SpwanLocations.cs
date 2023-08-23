using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanLocations : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject[] powerUps;
    //Boss
    public GameObject bossPrefab;
    public GameObject[] miniEnemyPrefabs;
    private int bossRound=3;
    //Boss

    private float spwanXD = 6f;
    private float spwanZD = 9f;
    private float spwanYD = 0.5f;

    private int enemyCounts;
    private int wave=1;

    void Start()
    {
        SpwanEnemy(wave);
        SpwanPowerUp();
    }

    private void Update()
    {
        enemyCounts = FindObjectsOfType<Enemy>().Length;

        if(enemyCounts==0)
        {
            wave++;
            SpwanPowerUp();

            if (wave % bossRound == 0)
            {
                SpawnBossWave(wave);
            }
            else
            {
                SpwanEnemy(wave);
            }
        }
    }

    void SpwanEnemy(int enemysToSpwan)
    {
        for (int i = 0; i < enemysToSpwan; i++)
        {
            int index = Random.Range(0, enemys.Length);
            Instantiate(enemys[index], SpwanPos(), enemys[index].transform.rotation);
        }
    }
    void SpwanPowerUp()
    {
        int index = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[index], SpwanPos(), powerUps[index].transform.rotation);
    }
    Vector3 SpwanPos()
    {
        Vector3 spwanPos = new Vector3(Random.Range(-spwanXD, spwanXD), spwanYD, Random.Range(-spwanZD, spwanZD));
        return spwanPos;
    }
    void SpawnBossWave(int currentRound)
    {
        int miniEnemysToSpawn;
        //We dont want to divide by 0!
        if (bossRound != 0)
        {
            miniEnemysToSpawn = currentRound / bossRound;
        }
        else
        {
            miniEnemysToSpawn = 1;
        }
        var boss = Instantiate(bossPrefab, SpwanPos(),
        bossPrefab.transform.rotation);
        boss.GetComponent<Enemy>().miniEnemySpawnCount = miniEnemysToSpawn;
    }    public void SpawnMiniEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
            Instantiate(miniEnemyPrefabs[randomMini], SpwanPos(),
            miniEnemyPrefabs[randomMini].transform.rotation);
        }
    }
}
