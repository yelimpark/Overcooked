using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FadeInOutUI : MonoBehaviour
{
    public float posX, posY;
    public float time;
    public float delayTime;

    public GameObject FadeUI;
    public UnityEvent OnCompleteEvent;
    


    public void FadeInUI()
    {
        iTween.ScaleTo(FadeUI, iTween.Hash("scale", new Vector3(posX, posY, 1), "time", time, "delay", delayTime, "easetype", iTween.EaseType.easeInOutExpo, "oncomplete", "ExecuteEvent", "oncompletetarget", gameObject));
    }

    public void ExecuteEvent()
    {
        Debug.Log("???");
        OnCompleteEvent.Invoke();
    }

    public void FadeOutUI()
    {
        iTween.ScaleTo(FadeUI, iTween.Hash("scale", new Vector3(1,1,1), "time", time, "delay", delayTime, "easetype", iTween.EaseType.easeInOutExpo));
    }

    public void ChangeResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

}
