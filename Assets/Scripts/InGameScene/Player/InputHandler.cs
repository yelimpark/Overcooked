using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class InputHandler : MonoBehaviour
{
    //componant
    private EquipmentSystem es;
    private Animator animator;
    private Rigidbody rb;
    private PhotonView photonView;

    public Interact EquipmentCursor;
    public Interact InteractableCursor;

    // variable about movement
    public float speed;
    private float horizontal;
    private float vertical;

    void Start()
    {
        es = GetComponent<EquipmentSystem>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        photonView = PhotonView.Get(this);
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = new Vector3(horizontal, 0f, vertical) * speed;
        rb.velocity = newVelocity;
    }

    void Update()
    {
        // Movement
        if (!photonView.IsMine)
            return;

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

        // Interaction
        if (Input.GetButtonDown("Fire1"))
        {
            var equipment = es.hands.occupyObj;

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
         var dest = es.hands.gameObject;
        Interactable interactable = cursor.GetComponent<Interactable>();
        if (interactable != null)
        {
            var takeOut = interactable.TakeOut(dest);
            es.Equip(takeOut);
        }

        if (es.hands.gameObject != null)
            EquipmentCursor.Cursor = null;
    }

    [PunRPC]
    public void Place()
    {
        if (InteractableCursor.Cursor != null)
        {
            InteractableAppliances interactable = InteractableCursor.Cursor.GetComponent<InteractableAppliances>();
            if (interactable != null && interactable.slot.AbleToPlace(es.hands.occupyObj))
            {
                GameObject discarded = es.Unequip();
                es.UnequipEnd();
                interactable.slot.OnPlace(discarded);
                return;
            }
        }
        es.Unequip();
    }

    [PunRPC]
    public void OnZDown()
    {
        if (InteractableCursor.Cursor != null)
        {
            InteractableAppliances interactable = InteractableCursor.Cursor.GetComponent<InteractableAppliances>();
            if (interactable != null)
            {
                CuttingBoard cb = interactable.slot.GetComponent<CuttingBoard>();
                if (cb != null)
                {
                    cb.Trigger();
                    animator.SetBool("isChoping", true);
                }
            }
        }
    }
}
