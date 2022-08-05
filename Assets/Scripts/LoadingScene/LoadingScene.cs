using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;

public class LoadingScene : MonoBehaviour
{
    private static LoadingScene instance;
    public static LoadingScene Instance { get { return instance; } }

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

    [Header("Score")]
    public int parentScore;
    

    [Header("Get Scene Info")]
    public Image StageImage;
    public TextMeshProUGUI Titletext;
    public TextMeshProUGUI[] StarPoint;

    [Header("바뀔 Sprite")]
    public Image[] sprite = new Image[3];
    public Sprite YellowStar;


    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        //GameManager.Instance.DataManager.LoadStageData();

        StageImage.sprite = GameVariable.GetDefinition().StageImage;
        Titletext.text = GameVariable.GetDefinition().SceneName;
        SceneName = GameVariable.GetDefinition().SceneName;
        for(int i = 0; i < StarPoint.Length; i++)
        {
            StarPoint[i].text = GameVariable.GetDefinition().StarScores[i].ToString();
        }
        for (int i = 0; i < GameVariable.GetDefinition().StarScores.Length; i++)
        {
            //스타포인트와 내 점수를 비교해야해
            if(GameVariable.GetDefinition().JsonIndex == GameManager.Instance.DataManager.currentStageInfo[i].Index)
            {
                for (int j = 0; j < GameVariable.GetDefinition().StarScores.Length; j++)
                {
                    if (GameVariable.GetDefinition().StarScores[j] < GameManager.Instance.DataManager.currentStageInfo[i].score)
                    {
                        sprite[j].sprite = YellowStar;
                    }
                }
            }
        }

        //Debug.Log(GameManager.Instance.DataManager.currentStageInfo[0].successSubmit);

        ZoomIn.ZoomInUI();
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
            //time += Time.deltaTime;


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
       // float fakeLoadTime = 0f;
       // float fakeLoadRatio = 0f;
       // float loadRatio = 0f;

       // while (true)
       // {



       //     fakeLoadTime += Time.deltaTime;
       //     fakeLoadRatio = fakeLoadTime / minLoadingTime;

       //     //loadRatio
       //     //loadRatio = Mathf.Min(operation.progress + 0.1f, fakeLoadRatio);
       //     loadRatio = fakeLoadRatio;
       //     image.fillAmount = loadRatio;

       //     if (loadRatio >= 0.9f)
       //     {
       //         image.fillAmount = 1.0f;
       //         ZoomOut.ZoomOutUI();

       //         yield return new WaitForSeconds(2f);

       //         PhotonNetwork.LoadLevel(SceneName);
       //         break;
       //         //operation.allowSceneActivation = true;
       //     }

       // }
       //yield return null;
    }

}
