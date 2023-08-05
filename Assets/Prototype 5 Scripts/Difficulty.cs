using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    private GameHandeler gameHandeler;
    public float difficulty;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameHandeler = GameObject.Find("Game Handeler").GetComponent<GameHandeler>();
        button.onClick.AddListener(SetDifficulty);
    }

    public void SetDifficulty()
    {
        gameHandeler.StartGame(difficulty);
    }
}
