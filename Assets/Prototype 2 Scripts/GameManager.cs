using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scores=5;
    public int health=10;
   
    public void AddScores(int value)
    {
        scores += value;
        Debug.Log(scores);
    }
    public void AddLives(int value)
    {
        health += value;
        Debug.Log("Health : " + health);

        if(health<=0)
        {
            Debug.Log("GameOver!");
        }
        
    }
    
}
