using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireTimeBar : MonoBehaviour
{
    public GameObject fire;
    public float maxTime = 100f;
    public float currentTime = 100f;
    private Slider fireSlider;

    public void Awake()
    {
        fireSlider = GetComponent<Slider>();
    }

    public void Update()
    {
        maxTime -= Time.deltaTime;
        transform.position = fire.transform.position;
        fireSlider.value = currentTime / maxTime;  
    }
}
