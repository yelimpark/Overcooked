using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private static LoadingScene instance;
    public static LoadingScene Instance { get { return instance; } }

    [Header("Canvas UI")]
    public FadeInOutUI fadeInOutUI;
    public GameObject loadingUI;

    [Header("Loading Bar")]
    public Image image;

    [Header("LoadingTime")]
    public float minLoadingTime = 4.0f;

    [Header("Next Scene")]
    public string SceneName;

    public enum SceneNames
    {
        STARTSCENE,

    }

    private float time;


    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        fadeInOutUI.FadeInUI();
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
            time += Time.deltaTime;


            //loadRatio
            loadRatio = Mathf.Min(operation.progress + 0.1f, fakeLoadRatio);
            Debug.Log("Loading progress: " + (loadRatio * 100) + "%");
            image.fillAmount = loadRatio;

            
            
            if (loadRatio >= 0.9f)
            {
                image.fillAmount = 1.0f;
                fadeInOutUI.FadeOutUI();
                yield return new WaitForSeconds(2f);
                
                operation.allowSceneActivation = true;
            }
            
            yield return null;
            
        }
        

    }

}
