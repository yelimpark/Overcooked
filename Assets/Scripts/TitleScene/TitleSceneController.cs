using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneController : MonoBehaviour
{
    [Header("Loading Scene")]
    public string nextSceneName = "LoadingWorldScene";
    public static bool NewScene;
    public AudioSource pressButtonSound;

    public void LoadWorldScene()
    {
        pressButtonSound.Play();
        NewScene = false;
        //Debug.Log(GameManager.Instance.TitleSceneController.NewScene);
        SceneManager.LoadScene(nextSceneName);
    }
    public void LoadNewWorldScene()
    {
        pressButtonSound.Play();
        NewScene = true;
        //Debug.Log(GameManager.Instance.TitleSceneController.NewScene);
        SceneManager.LoadScene(nextSceneName);
    }
}
