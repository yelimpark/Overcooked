using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireTimeBar : MonoBehaviour
{    
    public float maxTime = 100f;
    public float currentTime;
    private Slider fireSlider;

    public void Awake()
    {
        fireSlider = GetComponent<Slider>();
        currentTime = maxTime;
    }  
    
}
