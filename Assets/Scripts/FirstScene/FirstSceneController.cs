using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneController : MonoBehaviour
{
    [Header("On/Off UI")]
    public GameObject Hamburger;

    [Header("Next Scene")]
    public string SceneName;

    [Header("LoadingTime")]
    public float minLoadingTime = 4.0f;

    private void Start()
    {
        Hamburger.SetActive(false);
        StartCoroutine(LoadAsynScene());
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
            
            Hamburger.SetActive(true);
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
