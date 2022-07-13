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
    public Player player;

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
    public TimeController timeController;
    public TimerBar timerBar;
    private void Start()
    {
        HelpUI.SetActive(true);
        PlayerUI.SetActive(false);
        ReadyUI.SetActive(false);
        StartUI.SetActive(false);
        player.enabled = false;

    }

    private void Update()
    {
        //Debug.Log(Time.deltaTime);
        if(Input.GetKey(KeyCode.Space))
        {
            //After 3sec -> PlayerUI true
            pressTime += LoadingSpeed * Time.deltaTime;
            if (pressTime >= 50)
            {
                StartCoroutine(ChangeUI());
                pressTime = 0;
            }
            
        }
        else
        {
            pressTime = 0f;
        }
        LoadingBar.fillAmount = pressTime/50;
    }

    IEnumerator ChangeUI()
    {
        timeController.GetComponent<TimeController>().enabled = false;
        timerBar.GetComponent<TimerBar>().enabled = false;
        HelpUI.SetActive(false);

        player.enabled = false;
        mainCamera.CameraZoomIn();
        PlayerUI.SetActive(true);

        yield return new WaitForSecondsRealtime(3f);
        ReadyUI.SetActive(true);


        yield return new WaitForSecondsRealtime(3f);

        ReadyUI.SetActive(false);
        StartUI.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        
        ReadyUI.SetActive(false);
        StartUI.SetActive(false);
        player.enabled = true;

        timeController.GetComponent<TimeController>().enabled = true;
        timerBar.GetComponent<TimerBar>().enabled = true;


    }
}
