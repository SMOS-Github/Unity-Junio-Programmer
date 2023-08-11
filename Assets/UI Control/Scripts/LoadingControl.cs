using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingControl : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider loadingBar;

    public float minLoadTime=10f;

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadingAsync(sceneIndex));
    }

    IEnumerator LoadingAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingPanel.gameObject.SetActive(true);

        float timeLeft = 0;

        while (!operation.isDone)
        {
            float progerss = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.value = progerss;
            timeLeft += Time.deltaTime;
            yield return null;
        }
        while(timeLeft<minLoadTime)
        {
            timeLeft += Time.deltaTime;
            yield return null;

        }
    }
}
