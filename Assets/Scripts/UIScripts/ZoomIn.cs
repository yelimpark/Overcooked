using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ZoomIn : MonoBehaviour
{
    public float posX, posY;
    public float time;
    public float delayTime;

    public GameObject ZoomUI;
    public UnityEvent OnCompleteEvent;

    public string loadScene;


    public void ZoomInUI()
    {
        iTween.ScaleTo(ZoomUI, iTween.Hash("scale", new Vector3(posX, posY, 1), "time", time, "delay", delayTime, "easetype", iTween.EaseType.easeInOutExpo, "oncomplete", "ExecuteEvent", "oncompletetarget", gameObject));
    }

    public void ExecuteEvent()
    { 
        OnCompleteEvent.Invoke();
    }

    public void ChangeResultScene()
    {
        SceneManager.LoadScene(loadScene);
    }
}
