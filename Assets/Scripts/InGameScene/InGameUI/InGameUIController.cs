using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    [Header("On/Off UI")]
    public GameObject FadeUI;
    public GameObject HelpUI;
    public GameObject PlayerUI;
    public GameObject ReadyUI;
    public GameObject StartUI;
    public GameObject EndUI;
    public InputHandler player;
    public GameObject orderUI;
    public GameObject Joystick;

    [Header("To Zoom UI's")]
    public ZoomIn ZoomUI;
    public ZoomIn ZoomReadyUI;
    public ZoomIn ZoomStartUI;
    public ZoomIn ZoomEndUI;

    [Header("Loading Circle")]
    public Image LoadingBar;
    private float pressTime;
    public float LoadingSpeed;

    [Header("First Bigger Layer")]
    public float posX, posY;
    public float time;
    public float delayTime;

    [Header("Camera Moving")]
    public CameraController mainCamera;
    
    [Header("Time Bar And StopWatch")]
    public TimeController timeController;
    public TimerBar timerBar;
    public bool HelpOn;

    public KitchenManager km;

    private void Start()
    {
        ZoomUI.ZoomInUI();
        FadeUI.SetActive(true);
        HelpUI.SetActive(true);
        PlayerUI.SetActive(false);
        ReadyUI.SetActive(false);
        StartUI.SetActive(false);
        EndUI.SetActive(false);
        orderUI.SetActive(false);
        //Joystick.SetActive(false);
        HelpOn = true;
        //player.enabled = false;

    }

    private void Update()
    {
        //Debug.Log(Time.deltaTime);
#if UNITY_STANDALONE
        if(Input.GetKey(KeyCode.Space))
        {
            //After 3sec -> PlayerUI true
            pressTime += LoadingSpeed * Time.deltaTime;
            if (pressTime >= 1.5)
            {
                StartCoroutine(ChangeUI());
                pressTime = 0;
            }
            
        }
        else
        {
            pressTime = 0f;
        }
#endif
#if UNITY_ANDROID
        if (Input.anyKey && HelpOn)
        {
            //After 3sec -> PlayerUI true
            pressTime += LoadingSpeed * Time.deltaTime;
            if (pressTime >= 1.5)
            {
                StartCoroutine(ChangeUI());
                pressTime = 0;
                HelpOn = false;
            }

        }
        else
        {
            pressTime = 0f;
        }
#endif
        LoadingBar.fillAmount = pressTime / 1.5f;

        if (timeController.time <= 0f)
        {
            EndUI.SetActive(true);
            GameManager.Instance.DataManager.SaveStageData();
            km.SetStageInfo();
            ZoomEndUI.ZoomInUI();
            timeController.time = 0;
            //player.enabled = false;
        }
    }

    IEnumerator ChangeUI()
    {
        timeController.GetComponent<TimeController>().enabled = false;
        timerBar.GetComponent<TimerBar>().enabled = false;
        HelpUI.SetActive(false);

        //player.enabled = false;
        mainCamera.CameraZoomIn();
        PlayerUI.SetActive(true);

        yield return new WaitForSecondsRealtime(1f);
        ReadyUI.SetActive(true);
        if(ReadyUI)
        {
            ZoomReadyUI.ZoomInUI();
        }

        yield return new WaitForSecondsRealtime(1.5f);

        ReadyUI.SetActive(false);
        StartUI.SetActive(true);
        if (StartUI)
        {
            ZoomStartUI.ZoomInUI();
        }
        yield return new WaitForSecondsRealtime(1f);
        
        ReadyUI.SetActive(false);
        StartUI.SetActive(false);
        orderUI.SetActive(true);
        //Joystick.SetActive(true);

        //player.enabled = true;

        timeController.GetComponent<TimeController>().enabled = true;
        timerBar.GetComponent<TimerBar>().enabled = true;


    }

}
