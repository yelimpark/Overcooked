using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public float time;
    public float delayTime;

    public GameObject FadeUI;
    public UnityEvent OnCompleteEvent;

    public string loadScene;

    public void FadeOutUI()
    {
        iTween.ScaleTo(FadeUI, iTween.Hash("scale", new Vector3(1, 1, 1), "time", time, "delay", delayTime, "easetype", iTween.EaseType.easeInOutExpo, "oncomplete", "ExecuteEvent2", "oncompletetarget", gameObject));
    }
    public void ExecuteEvent2()
    {
        Debug.Log("이걸왜타");
        OnCompleteEvent.Invoke();
    }


    public void ChangeResultScene2()
    {
        SceneManager.LoadScene(loadScene);
    }

}