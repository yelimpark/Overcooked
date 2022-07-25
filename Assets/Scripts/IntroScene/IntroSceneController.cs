using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
    [Header("Fade될 UI")]
    public FadeIn target1;
    public FadeIn target2;
    public FadeIn target3;
    public FadeIn target4;

    [Header("On/Off UI")]
    public GameObject Canvas1;
    public GameObject Canvas2;
    public GameObject Canvas3;
    public GameObject Canvas4;

    [Header("시간 설정")]
    private float accumTime = 3f;

    [Header("Next Scene")]
    public string SceneName;

    [Header("LoadingTime")]
    public float minLoadingTime = 13.0f;

    private void Start()
    {
        Canvas1.SetActive(false);
        Canvas2.SetActive(false);
        Canvas3.SetActive(false);
        Canvas4.SetActive(false);
        StartCoroutine(FadeInOut());
        StartCoroutine(LoadAsynScene());
    }

    IEnumerator FadeInOut()
    {
        Canvas1.SetActive(true);
        target1.StartFadeIn();
        yield return new WaitForSeconds(accumTime);
        Canvas2.SetActive(true);
        target2.StartFadeIn();
        yield return new WaitForSeconds(accumTime);
        Canvas3.SetActive(true);
        target3.StartFadeIn();
        yield return new WaitForSeconds(accumTime);
        Canvas4.SetActive(true);
        target4.StartFadeIn();
        yield return new WaitForSeconds(accumTime);
    }

    IEnumerator LoadAsynScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        operation.allowSceneActivation = false;

        float fakeLoadTime = 0f;
        float fakeLoadRatio = 0f;
        float loadRatio = 0f;

        yield return new WaitForSeconds(0.5f);

        while (!operation.isDone)
        { 
            fakeLoadTime += Time.deltaTime;
            fakeLoadRatio = fakeLoadTime / minLoadingTime;

            //loadRatio
            loadRatio = Mathf.Min(operation.progress + 0.1f, fakeLoadRatio);

            if (loadRatio >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;

        }


    }
}
