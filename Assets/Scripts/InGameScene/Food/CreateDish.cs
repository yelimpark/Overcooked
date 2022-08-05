using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDish : MonoBehaviour
{
    public float timer;
    private InteractableCreate createObject;
    public Transform spon;


    private void Start()
    {
        createObject = GetComponent<InteractableCreate>();
    }
    private void Update()
    {
    }

    public void GenerateDish()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            timer = 0f;
            createObject.Create();
        }
    }
}