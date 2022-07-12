using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    [Header("On/Off UI")]
    public GameObject HelpUI;
    public GameObject PlayerUI;
    public Player player;

    [Header("Loading Circle")]
    public Image LoadingBar;
    private float pressTime;
    public float LoadingSpeed;

    private void Start()
    {
        HelpUI.SetActive(true);
        PlayerUI.SetActive(false);
        player.enabled = false;

    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("´©¸§");
            //After 3sec -> PlayerUI true
            pressTime += LoadingSpeed * Time.deltaTime;
            if (pressTime >= 50)
            {
                HelpUI.SetActive(false);
                PlayerUI.SetActive(true);
                player.enabled = true;
                
            }
            
        }
        else
        {
            pressTime = 0f;
        }
        LoadingBar.fillAmount = pressTime/50;
    }
}
