using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandeler : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    public GameObject restartButton;
    public GameObject gameTitle;
    public GameObject pasuePanel;

    public Text scoreText;
    public Text timeText;
    public Text livesText;

    public float maxTime;
    private float noTime = 0;
    public float spwanRate = 2f;
    public int score;
    public int lives;

    public bool paused;
    public bool gameOver;
    public bool gameIsActive = false;

    public void Start()
    {

    }
    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pasuePanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pasuePanel.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void Update()
    {
        if (gameIsActive == true)
        {
            Mathf.Round(maxTime -= Time.deltaTime);
            timeText.text = "Time:" + maxTime.ToString("0");
            if (maxTime < 0)
            {
                GameOver();
            }
            if (gameOver == true)
            {
                timeText.text = "Time:" + noTime.ToString("0");
            }

        }
        if (Input.GetKeyDown(KeyCode.Escape) && gameIsActive == true)
        {
            ChangePaused();
        }
    }



    public void UpdateScore(int addToScore)
    {
        score += addToScore;
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        gameOver = true;
        restartButton.gameObject.SetActive(true);
    }

    public void StartGame(float difficulty)
    {
        spwanRate /= difficulty;
        gameTitle.gameObject.SetActive(false);
        StartCoroutine(SpwanTargets());
        UpdateScore(score);
        UpdateLives(lives);
        gameIsActive = true;

    }

    IEnumerator SpwanTargets()
    {
        while (gameOver == false&&paused==false)
        {
            yield return new WaitForSeconds(spwanRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }
    public void UpdateLives(int totalLives)
    {
        lives += totalLives;
        livesText.text = "Lives : " + lives;
        if (lives <= 0)
        {
            GameOver();
        }
    }
    public void Restart(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

}
