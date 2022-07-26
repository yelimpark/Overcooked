using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class LoadingWorldScene : MonoBehaviour
{
    private static LoadingWorldScene instance;
    public static LoadingWorldScene Instance { get { return instance; } }

    [Header("Canvas UI")]
    public ZoomIn ZoomIn;
    public ZoomOut ZoomOut;
    public GameObject loadingUI;

    [Header("Loading Bar")]
    public Image image;

    [Header("LoadingTime")]
    public float minLoadingTime = 4.0f;

    [Header("To Loaded Scene")]
    public string SceneName;

    private float time;


    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        ZoomIn.ZoomInUI();
        StartCoroutine(LoadAsynWorldSceneCoroutine());
        
    }

    IEnumerator LoadAsynWorldSceneCoroutine()
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
            //Debug.Log("Loading progress: " + (loadRatio * 100) + "%");
            image.fillAmount = loadRatio;



            if (loadRatio >= 0.9f)
            {
                image.fillAmount = 1.0f;
                ZoomOut.ZoomOutUI();
                yield return new WaitForSeconds(2f);

                operation.allowSceneActivation = true;
            }

            yield return null;

        }

        //    float fakeLoadTime = 0f;
        //    float fakeLoadRatio = 0f;
        //    float loadRatio = 0f;

        //    while (true)
        //    {
        //        fakeLoadTime += Time.deltaTime;
        //        fakeLoadRatio = fakeLoadTime / minLoadingTime;

        //        //loadRatio
        //        //loadRatio = Mathf.Min(operation.progress + 0.1f, fakeLoadRatio);
        //        loadRatio = fakeLoadRatio;
        //        image.fillAmount = loadRatio;

        //        if (loadRatio >= 0.9f)
        //        {
        //            image.fillAmount = 1.0f;
        //            ZoomOut.ZoomOutUI();

        //            yield return new WaitForSeconds(2f);

        //            PhotonNetwork.LoadLevel(SceneName);
        //            break;
        //            //operation.allowSceneActivation = true;
        //        }

        //    }
        //    yield return null;
    }

}
