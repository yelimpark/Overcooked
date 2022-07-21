using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private EquipmentSystem _equipmentSystem;
    private Animator animator;
    public Interact EquipmentCursor;
    public Interact InteractableCursor;

    private PhotonView photonView;

    void Start()
    {
        _invoker = GetComponent<Invoker>();
        _equipmentSystem = GetComponent<EquipmentSystem>();
        animator = GetComponent<Animator>();
        photonView = PhotonView.Get(this);
    }

    void Update()
    {
        //if (!photonView.IsMine)
        //{
        //    return;
        //}

        if (Input.GetButtonDown("Fire1"))
        {
            if (animator.GetBool("isPickUp"))
            {
                if (InteractableCursor.Cursor == null)
                {
                    _invoker.ExecuteCommand(new Release(_equipmentSystem));
                }
                else
                {
                    _invoker.ExecuteCommand(new Place(_equipmentSystem, InteractableCursor.Cursor));
                }
            }
            else
            {
                var cursor = (EquipmentCursor.Cursor != null) ? EquipmentCursor.Cursor : InteractableCursor.Cursor;
                _invoker.ExecuteCommand(new TakeOut(_equipmentSystem, cursor));
            }
        }

    }
}
