using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public TimeController timeCtr;
    public Slider TimerSlider;
    public Image timerBar;

    private Color timeMaxColor;
    private Color timeMedianColor = new Color(250 / 255f, 250 / 255f, 80 / 255f);
    private Color timeMinColor = new Color(250 / 255f, 50 / 255f, 15 / 255f);

    //float time = 150f;
    private void Start()
    {
        TimerSlider = GetComponent<Slider>();
        timeMaxColor = timerBar.color;

        TimerSlider.maxValue = timeCtr.time;
        TimerSlider.value = TimerSlider.maxValue;
    }

    private void Update()
    {
        if (TimerSlider.value > 0.0f)
        {
            // 시간이 변경한 만큼 slider Value 변경
            TimerSlider.value -= Time.deltaTime;
            var halfTime = TimerSlider.maxValue * 0.5f;
            if (TimerSlider.value > halfTime)
            {
                var resultTime = (TimerSlider.value - halfTime) / halfTime;
                timerBar.color = Color.Lerp(timeMedianColor, timeMaxColor, resultTime);
            }
            else
            {
                timerBar.color = Color.Lerp(timeMinColor, timeMedianColor, TimerSlider.value / halfTime);
            }
        }
        else
        {
            //게임종료
            Debug.Log("Time is Zero.");
        }
    }
}
