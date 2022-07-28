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
            if (_equipmentSystem.Equipment == null)
            {
                //OnEquipBtn();
                PhotonView.Get(this).RPC("OnEquipBtn", RpcTarget.All);
            }
            else
            {
                if (_equipmentSystem.Equipment.tag == "Cookware" && InteractableCursor.Cursor != null)
                {
                    Cookware cookware = _equipmentSystem.Equipment.GetComponent<Cookware>();
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
            PhotonView.Get(this).RPC("OnZDown", RpcTarget.All);

            if (_equipmentSystem.Equipment.tag == "Cookware")
            {                
                FireRay fireRay = _equipmentSystem.Equipment.GetComponentInChildren<FireRay>();
                if (fireRay != null)
                {
                    fireRay.Shoot();
                    Debug.Log("Shoot");
                }
            }
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
        var dest = _equipmentSystem.Equipment;
        Interactable interactable = cursor.GetComponent<Interactable>();
        if (interactable != null)
        {
            var takeOut = interactable.TakeOut(dest);
            _equipmentSystem.Equip(takeOut);
        }
    }

    [PunRPC]
    public void Place()
    {
        if (InteractableCursor.Cursor != null)
        {
            InteractableAppliances interactable = InteractableCursor.Cursor.GetComponent<InteractableAppliances>();
            if (interactable != null && interactable.slot.AbleToPlace(_equipmentSystem.Equipment))
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
                CookingBehaviour cb = interactable.slot.gameObject.GetComponent<CookingBehaviour>();
                if (cb != null)
                {
                    cb.SetTrigger(true);
                    animator.SetBool("isChoping", true);
                }
            }
        }
    }
}
