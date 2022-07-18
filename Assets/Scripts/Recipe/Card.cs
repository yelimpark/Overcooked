using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Slider timer;
    public Image timerBar;
    public Animator animator;
    public float timeLimit;
    public bool isActive;

    private Color timeMaxColor;
    private Color timeMedianColor = new Color(250 / 255f, 250 / 255f, 80 / 255f);
    private Color timeMinColor = new Color(250 / 255f, 50 / 255f, 15 / 255f);

    private void Awake()
    {
        timer.maxValue = timeLimit;
        timer.value = timer.maxValue;
        timeMaxColor = timerBar.color;
    }

    private void Update()
    {
        if (isActive)
        {
            timer.value -= Time.deltaTime;
            var halfTime = timer.maxValue * 0.5f;
            if (timer.value > halfTime)
            {
                var resultTime = (timer.value - halfTime) / halfTime;
                timerBar.color = Color.Lerp(timeMedianColor, timeMaxColor, resultTime);
            }
            else
            {
                timerBar.color = Color.Lerp(timeMinColor, timeMedianColor, timer.value / halfTime);
                if (timer.value < 10f)
                {
                    animator.SetTrigger("isWarning");
                }
            }

            if (timer.value == 0f)
            {
                animator.SetTrigger("isTimeout");
            }
        }
    }

    public void DeleteCard()
    {

        Destroy(gameObject);
    }
}
