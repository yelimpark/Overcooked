using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    public Slider TimerSlider;

    

    //float time = 150f;
    void Start()
    {
        TimerSlider = GetComponent<Slider>();

    }

    void Update()
    {
        if (TimerSlider.value > 0.0f)
        {
            // 시간이 변경한 만큼 slider Value 변경
            TimerSlider.value -= Time.deltaTime;
        }
        else
        {
            //게임종료
            Debug.Log("Time is Zero.");
        }
    }
}
