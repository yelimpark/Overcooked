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

    private void Start()
    {
        ZoomUI.ZoomInUI();
        FadeUI.SetActive(true);
        HelpUI.SetActive(true);
        PlayerUI.SetActive(false);
        ReadyUI.SetActive(false);
        StartUI.SetActive(false);
        EndUI.SetActive(false);
        //player.enabled = false;

    }

    private void Update()
    {
        //Debug.Log(Time.deltaTime);
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
        LoadingBar.fillAmount = pressTime/1.5f;

        if(timeController.time <= 0f)
        {
            EndUI.SetActive(true);
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
        //player.enabled = true;

        timeController.GetComponent<TimeController>().enabled = true;
        timerBar.GetComponent<TimerBar>().enabled = true;


    }

}
