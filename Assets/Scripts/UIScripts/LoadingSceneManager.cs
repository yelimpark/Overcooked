using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public Image image;
    public string SceneName;

    public float minLoadingTime = 4.0f;

    public UISmallerAnimation smallerAnimation;
    private float time;


    void Start()
    {
        StartCoroutine(LoadAsynSceneCoroutine());
        
    }

    IEnumerator LoadAsynSceneCoroutine()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        operation.allowSceneActivation = false;

        float fakeLoadTime = 0f;
        float fakeLoadRatio = 0f;
        float loadRatio = 0f;

        while (!operation.isDone)
        {

            fakeLoadTime += Time.deltaTime;
            fakeLoadRatio = fakeLoadTime / minLoadingTime;
            time = +Time.time;

            image.fillAmount = operation.progress;

            //loadRatio
            loadRatio = Mathf.Min(operation.progress + 0.1f, fakeLoadRatio);
            Debug.Log("Loading progress: " + (loadRatio * 100) + "%");

            

            if (loadRatio >= 0.9f)
            {
                //yield return new WaitForSeconds(2f);
                
                operation.allowSceneActivation = true;
            }
            
            yield return null;
            
        }
        loadRatio = 1.0f;

    }

}
