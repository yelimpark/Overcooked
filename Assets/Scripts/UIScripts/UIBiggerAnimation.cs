using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBiggerAnimation : MonoBehaviour
{
    public float posX, posY;
    public float time;
    public float delayTime;
    void Start()
    {
        iTween.ScaleTo(gameObject, iTween.Hash("scale", new Vector3(posX, posY, 1), "time", time, "delay", delayTime, "easetype", iTween.EaseType.easeInOutExpo));
    }

}
