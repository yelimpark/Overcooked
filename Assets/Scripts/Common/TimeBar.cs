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

    [System.NonSerialized]
    public bool pause = false;
    [System.NonSerialized]
    public bool end = false;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void Init()
    {
        timer = 0f;
        pause = false;
        end = false;
    }

    void Update()
    {
        if (pause || end)
            return;

        timer += Time.deltaTime;
        slider.value = timer / time;

        if (timer > time)
        {
            end = true;
            TimeUpEvent.Invoke();
            gameObject.SetActive(false);
        }
    }
}
