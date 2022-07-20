using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private EquipmentSystem _equipmentSystem;
    private Interact EquipmentCursor;
    private Interact InteractableCursor;

    void Start()
    {
        _invoker = GetComponent<Invoker>();
        _equipmentSystem = GetComponent<EquipmentSystem>();
        EquipmentCursor = GetComponents<Interact>()[0];
        InteractableCursor = GetComponents<Interact>()[1];
    }

    void Update()
    {

        // if (Input.GetButtonDown("Fire1"))
        //    _invoker.ExecuteCommand(new Grab());
    }
}
