using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    public GameObject gameOverText;
    public bool gameOver = false;
    public int scores=5;
    public int health=10;
   
    public void AddScores(int value)
    {
        scores += value;
        scoreText.text = ""+ scores;
    }
    public void AddLives(int value)
    {
        health += value;
        healthText.text = ""+ health;

        if(health<=0)
        {
            gameOverText.gameObject.SetActive(true);
            gameOver = true;
        }
        
    }
    public void Restart(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        gameOverText.gameObject.SetActive(false);
    }
}
