using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ZoomOut : MonoBehaviour
{
    public float time;
    public float delayTime;

    public GameObject ZoomUI;
    public UnityEvent OnCompleteEvent;

    public string loadScene;

    public AudioSource audioSource;
    public AudioClip zoomSound;

    public void ZoomOutUI()
    {
        audioSource.clip = zoomSound;
        audioSource.PlayDelayed(0.5f);
        iTween.ScaleTo(ZoomUI, iTween.Hash("scale", new Vector3(1, 1, 1), "time", time, "delay", delayTime, "easetype", iTween.EaseType.easeInOutExpo, "oncomplete", "ExecuteEvent2", "oncompletetarget", gameObject));
    }
    public void ExecuteEvent2()
    {
        OnCompleteEvent.Invoke();
    }


    public void ChangeResultScene2()
    {
        //if (!PhotonNetwork.IsMasterClient)
        //{
        //    return;
        //}
        //PhotonNetwork.LoadLevel(loadScene);

        SceneManager.LoadScene(loadScene);
    }

}