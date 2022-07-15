using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimeBar : MonoBehaviour
{
    public float time;
    private float timer = 0f;
    
    public UnityEvent TimeUpEvent;

    private Slider slider;

    public bool pause = false;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (pause)
            return;

        timer += Time.deltaTime;
        slider.value = timer / time;

        if (timer > time)
        {
            TimeUpEvent.Invoke();
            gameObject.SetActive(false);
        }
    }
}
