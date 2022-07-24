using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeController : MonoBehaviour
{
    public Animator animator;

    [Header("Time Control")]
    public TextMeshProUGUI[] timeText;
    //public TextMeshProUGUI gameOverText;
    public float time = 150f;
    private float startTime;
    private int minite, second;

    public bool isHalf;

    private void Start()
    {
        timeText[0].text = "00";
        timeText[1].text = "00";

        startTime = time;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        minite = (int)time / 60;
        second = (Mathf.CeilToInt(time - minite * 60)) % 60;
        if (minite <= 0 && second <= 0)
        {
            if (time % 30 == 0)
                timeText[0].text = 0.ToString("D2");
            timeText[1].text = 0.ToString("D2");
        }
        else
        {
            if (second >= 60)
            {
                minite += 1;
                second -= 60;
            }
            else
            {
                timeText[0].text = minite.ToString("D2");
                timeText[1].text = second.ToString("D2");
            }
        }

        if (second == 30 && minite == 0)
        {
            animator.SetTrigger("isEnd");
        }
        else if ((second == 30 || second == 0) && !isHalf && time < startTime - 1f)
        {
            animator.SetTrigger("isHalf");
        }
    }
}
