using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InputHandler : MonoBehaviour
{
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
        if (!photonView.IsMine)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 moveVec = new Vector3(horizontal, 0f, vertical).normalized;
        if (moveVec != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveVec.x, moveVec.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
            animator.SetBool("isChoping", false);
        }
        animator.SetBool("isWalking", moveVec != Vector3.zero);

        if (Input.GetButtonDown("Fire1"))
        {
            var equipment = _equipmentSystem.hands.occupyObj;

            if (equipment == null)
            {
                //OnEquipBtn();
                PhotonView.Get(this).RPC("OnEquipBtn", RpcTarget.All);
            }
            else
            {
                if (equipment.tag == "Cookware" && InteractableCursor.Cursor != null)
                {
                    Cookware cookware = equipment.GetComponent<Cookware>();
                    InteractableAppliances ia = InteractableCursor.Cursor.GetComponent<InteractableAppliances>();
                    if (ia.slot.occupyObj != null)
                    {
                        //OnEquipBtn();
                        PhotonView.Get(this).RPC("OnEquipBtn", RpcTarget.All);
                        return;
                    }
                }

                PhotonView.Get(this).RPC("Place", RpcTarget.All);
                //Place();
            }
        }
        if(Input.GetButton("Fire4"))
        {
            OnZDown();
            //PhotonView.Get(this).RPC("OnZDown", RpcTarget.All);

            //if (_equipmentSystem.Equipment.tag == "Cookware")
            //{                
            //    FireRay fireRay = _equipmentSystem.Equipment.GetComponentInChildren<FireRay>();
            //    if (fireRay != null)
            //    {
            //        fireRay.Shoot();
            //        Debug.Log("Shoot");
            //    }
            //}
        }

    }

    [PunRPC]
    public void OnEquipBtn()
    {
        if (InteractableCursor.Cursor != null)
            TakeOut(InteractableCursor.Cursor);
        if (EquipmentCursor.Cursor != null)
            TakeOut(EquipmentCursor.Cursor);
    }

    public void TakeOut(GameObject cursor)
    {
        var dest = _equipmentSystem.hands.gameObject;
        Interactable interactable = cursor.GetComponent<Interactable>();
        if (interactable != null)
        {
            var takeOut = interactable.TakeOut(dest);
            _equipmentSystem.Equip(takeOut);
        }

        if (_equipmentSystem.hands.gameObject != null)
            EquipmentCursor.Cursor = null;
    }

    [PunRPC]
    public void Place()
    {
        if (InteractableCursor.Cursor != null)
        {
            InteractableAppliances interactable = InteractableCursor.Cursor.GetComponent<InteractableAppliances>();
            if (interactable != null && interactable.slot.AbleToPlace(_equipmentSystem.hands.occupyObj))
            {
                GameObject discarded = _equipmentSystem.Unequip();
                _equipmentSystem.UnequipEnd();
                interactable.slot.OnPlace(discarded);
                return;
            }
        }
        _equipmentSystem.Unequip();
    }

    [PunRPC]
    public void OnZDown()
    {
        if (InteractableCursor.Cursor != null)
        {
            InteractableAppliances interactable = InteractableCursor.Cursor.GetComponent<InteractableAppliances>();
            if (interactable != null)
            {
                Cookware cookware = interactable.slot.GetComponent<Cookware>();
                if (cookware != null)
                {
                    cookware.Execute(true);
                    animator.SetBool("isChoping", true);
                }
            }
        }
    }
}
