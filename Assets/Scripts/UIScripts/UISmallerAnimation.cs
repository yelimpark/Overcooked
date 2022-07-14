using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UISmallerAnimation : MonoBehaviour
{
    public float posX, posY;
    public float time;
    public float delayTime;

    //public UnityEvent OnCompleteEvent;

    public void EndSceneFadeIn()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(posX, posY, 1), "time", time, "delay", delayTime, "easetype", iTween.EaseType.easeInOutExpo));
        //iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(posX, posY, 1), "time", time, "delay", delayTime, "easetype", iTween.EaseType.easeInOutExpo, "oncomplete", "OnCompleteEvent.Invoke"));
    }


}