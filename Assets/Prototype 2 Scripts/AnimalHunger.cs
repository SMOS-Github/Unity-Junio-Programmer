using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider happyBar;
    public int amountToBefed;
    private int currentFedAmt = 0;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        happyBar.maxValue = amountToBefed;
        happyBar.value = 0;
        happyBar.fillRect.gameObject.SetActive(false);
    }

   
    public void FeedAnimals(int amount)
    {
        currentFedAmt += amount;
        happyBar.fillRect.gameObject.SetActive(true);
        happyBar.value = currentFedAmt;
        if(currentFedAmt>=amountToBefed)
        {
            gameManager.AddScores(amountToBefed);
            Destroy(gameObject, 0.1f);
        }
    }
}
