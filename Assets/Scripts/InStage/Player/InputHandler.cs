using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InputHandler : MonoBehaviour
{
    private Invoker _invoker;
    private EquipmentSystem _equipmentSystem;
    private Animator animator;
    private Rigidbody rb;
    public Interact EquipmentCursor;
    public Interact InteractableCursor;

    private PhotonView photonView;

    public float speed;

    private float horizontal;
    private float vertical;

    void Start()
    {
        _invoker = GetComponent<Invoker>();
        _equipmentSystem = GetComponent<EquipmentSystem>();
        animator = GetComponent<Animator>();
        photonView = PhotonView.Get(this);
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = new Vector3(horizontal, 0f, vertical) * speed;
        rb.velocity = newVelocity;
    }

    void Update()
    {
        //if (!photonView.IsMine)
        //{
        //    return;
        //}

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveVec = new Vector3(horizontal, 0f, vertical).normalized;
        if (moveVec != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveVec.x, moveVec.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        animator.SetBool("isWalking", moveVec != Vector3.zero);

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
                InteractableCursor.enabled = false;
            }
            else
            {
                var cursor = (EquipmentCursor.Cursor != null) ? EquipmentCursor.Cursor : InteractableCursor.Cursor;
                _invoker.ExecuteCommand(new TakeOut(_equipmentSystem, cursor));
            }
        }

    }
}
