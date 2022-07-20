using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private EquipmentSystem _equipmentSystem;
    private Interact EquipmentCursor;
    private Interact InteractableCursor;

    private PhotonView photonView;

    void Start()
    {
        _invoker = GetComponent<Invoker>();
        _equipmentSystem = GetComponent<EquipmentSystem>();
        EquipmentCursor = GetComponents<Interact>()[0];
        InteractableCursor = GetComponents<Interact>()[1];
        photonView = PhotonView.Get(this);
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            var dest = _equipmentSystem.EquipableTo();
            if (dest == null)
            {
                _invoker.ExecuteCommand(new Release(_equipmentSystem));
            }
            else if (dest == gameObject)
            {
                if (EquipmentCursor.Cursor == null)
                {

                }
                else
                {
                    _invoker.ExecuteCommand(new PickUp(_equipmentSystem, EquipmentCursor.Cursor));
                }
            }
            else
            {

            }
        }
            
    }
}
