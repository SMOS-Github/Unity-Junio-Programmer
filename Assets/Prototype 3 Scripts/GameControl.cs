using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private int score=0;
    private float lerping=5.0f;
    public Transform startPoint;
    private PlayerMove playerScript;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerMove>();
        score = 0;
        playerScript.gameOver = true;
        StartCoroutine(PlayIntro());
    }
    private void Update()
    {
        if (playerScript.gameOver == false)
        {
            score += 1;

            if (playerScript.doubbleJump)
            {
                score += 3;
            }
        }
        Debug.Log("Scores :" + score);
    }
    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerScript.transform.position;
        Vector3 endpos = startPoint.transform.position;
        float journyLength = Vector3.Distance(startPos, endpos);
        float startTime = Time.time;

        float distanceCover = (Time.time - startTime) * lerping;
        float fractionJourny = distanceCover / journyLength;

        playerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);
        while (fractionJourny < 1)
        {
            distanceCover = (Time.time) * lerping;
            fractionJourny = distanceCover / journyLength;
            playerScript.transform.position = Vector3.Lerp(startPos, endpos, fractionJourny);
            yield return null;
        }
        playerScript.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1.0f);
        playerScript.gameOver = false;
    }
}
