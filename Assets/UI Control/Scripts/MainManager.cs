using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip playBt;
    public AudioClip click;
    public AudioClip playBack;

    public GameObject titleSceen;
    public GameObject menuSceen;

    public GameObject prototypesC;
    public GameObject challangesC;
    public GameObject extrasC;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        titleSceen.gameObject.SetActive(false);
        menuSceen.gameObject.SetActive(true);
        audioSource.PlayOneShot(playBt, 1f);
    }
    
    public void BackM()
    {
        titleSceen.gameObject.SetActive(true);
        menuSceen.gameObject.SetActive(false);
        audioSource.PlayOneShot(playBack, 1f);
    }
    public void BackP()
    {
        prototypesC.gameObject.SetActive(false);
        menuSceen.gameObject.SetActive(true);
        audioSource.PlayOneShot(playBack, 1f);
    }
    public void BackC()
    {
        challangesC.gameObject.SetActive(false);
        menuSceen.gameObject.SetActive(true);
        audioSource.PlayOneShot(playBack, 1f);
    }
    public void BackE()
    {
        extrasC.gameObject.SetActive(false);
        menuSceen.gameObject.SetActive(true);
        audioSource.PlayOneShot(playBack, 1f);
    }


    public void Prototype()
    {
        menuSceen.gameObject.SetActive(false);
        prototypesC.gameObject.SetActive(true);
        audioSource.PlayOneShot(playBt, 1f);
    }

    public void Challange()
    {
        menuSceen.gameObject.SetActive(false);
        challangesC.gameObject.SetActive(true);
        audioSource.PlayOneShot(playBt, 1f);
    }

    public void Extra()
    {
        menuSceen.gameObject.SetActive(false);
        extrasC.gameObject.SetActive(true);
        audioSource.PlayOneShot(playBt, 1f);
    }




    public void Exit()
    {

#if UNITY_EDITOR
        
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
