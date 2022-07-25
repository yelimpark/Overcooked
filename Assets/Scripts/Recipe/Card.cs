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
    public int submitScore;
    public int timeoutScore;
    public bool isActive;

    private CardManager cardMgr;
    private Color timeMaxColor;
    private Color timeMedianColor = new Color(250 / 255f, 250 / 255f, 80 / 255f);
    private Color timeMinColor = new Color(250 / 255f, 50 / 255f, 15 / 255f);

    private void Awake()
    {
        cardMgr = transform.GetComponentInParent<CardManager>();

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
                cardMgr.kitchenMgr.LostScores(timeoutScore);
                cardMgr.audioSource.clip = cardMgr.sounds[1];
                cardMgr.audioSource.Play();
                animator.SetTrigger("isTimeout");
            }
        }
    }

    public bool SuccessSubmission()
    {
        bool isFever = false;
        if (timer.value > timer.maxValue * 0.5f)
        {
            isFever = true;
        }
        animator.SetTrigger("isSuccess");
        return isFever;
    }

    public void WrongSubmission()
    {
        animator.SetTrigger("isWrong");
    }

    public void DeleteCard()
    {
        cardMgr.submitList.Remove(gameObject);
        Destroy(gameObject);
    }
}
