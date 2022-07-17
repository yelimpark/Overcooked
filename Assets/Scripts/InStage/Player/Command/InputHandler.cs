using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Invoker _invoker;
    public PlayerController _controller;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            _invoker.ExecuteCommand(new Grab());

    }
}
