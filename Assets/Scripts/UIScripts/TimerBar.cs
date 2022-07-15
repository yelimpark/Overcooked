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
            // �ð��� ������ ��ŭ slider Value ����
            TimerSlider.value -= Time.deltaTime;
        }
        else
        {
            //��������
            Debug.Log("Time is Zero.");
        }
    }
}
