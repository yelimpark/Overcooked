using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    [Header("Loading Scene")]
    public string nextSceneName = "LoadingWorldScene";
    public static bool NewScene;

    public void LoadWorldScene()
    {
        NewScene = false;
        //Debug.Log(GameManager.Instance.TitleSceneController.NewScene);
        SceneManager.LoadScene(nextSceneName);
    }
    public void LoadNewWorldScene()
    {
        NewScene = true;
        //Debug.Log(GameManager.Instance.TitleSceneController.NewScene);
        SceneManager.LoadScene(nextSceneName);

    }
}
