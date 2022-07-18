using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    [Header("On/Off UI")]
    public GameObject HelpUI;
    public GameObject PlayerUI;
    public GameObject ReadyUI;
    public GameObject StartUI;
    public GameObject EndUI;
    public Player player;

    [Header("To Fade UI's")]
    public FadeIn FadeUI;
    public FadeIn FadeReadyUI;
    public FadeIn FadeStartUI;
    public FadeIn FadeEndUI;

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
        FadeUI.FadeInUI();
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
            FadeEndUI.FadeInUI();
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
            FadeReadyUI.FadeInUI();
        }

        yield return new WaitForSecondsRealtime(1.5f);

        ReadyUI.SetActive(false);
        StartUI.SetActive(true);
        if (StartUI)
        {
            FadeStartUI.FadeInUI();
        }
        yield return new WaitForSecondsRealtime(2f);
        
        ReadyUI.SetActive(false);
        StartUI.SetActive(false);
        //player.enabled = true;

        timeController.GetComponent<TimeController>().enabled = true;
        timerBar.GetComponent<TimerBar>().enabled = true;


    }

}
