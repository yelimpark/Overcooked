using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    [Header("Time Text")]
    public TextMeshProUGUI[] timeText;
    //public TextMeshProUGUI gameOverText;
    float time = 150f;
    int minite, second;


    void Start()
    {

        timeText[0].text = "0";
        timeText[1].text = "00";
        
    }

    void Update()
    {
       
        time -= Time.deltaTime;
        minite = (int)time / 60;
        second = ((int)time - minite * 60) % 60;

        if (minite <= 0 && second <= 0)
        {
            timeText[0].text = 0.ToString();
            timeText[1].text = 0.ToString();
        }

        else
        {
            if(second >= 60)
            {
                minite += 1;
                second -= 60;

            }
            else
            {
                timeText[0].text = minite.ToString();
                timeText[1].text = second.ToString();
            }
        }    
    }
}
