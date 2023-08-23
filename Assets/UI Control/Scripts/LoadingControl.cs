using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingControl : MonoBehaviour
{
    public GameObject loadingPanal;
    public Slider slider;

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadingAsync(sceneIndex));
        
    }

    IEnumerator LoadingAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingPanal.gameObject.SetActive(true);

        while (!operation.isDone)
        {
            float progerss = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progerss;

            yield return null;
        }
        
    }
}
