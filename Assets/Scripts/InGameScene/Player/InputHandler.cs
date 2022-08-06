using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

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

    public VirtualJoyStick joystick;
    public Button GrabButton;
    public Button KnifeButton;

    void Start()
    {
        es = GetComponent<EquipmentSystem>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        photonView = PhotonView.Get(this);
#if UNITY_ANDROID
        GrabButton.onClick.AddListener(GetGrabButtonDown);
        KnifeButton.onClick.AddListener(GetKnifeButtonDown);
#endif
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

#if UNITY_STANDALONE
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
#endif
#if UNITY_ANDROID
        horizontal = joystick.GetAxis("Horizontal");
        vertical = joystick.GetAxis("Vertical");
#endif

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
            var equipment = es.hands.OccupyObj;

            if (equipment == null)
            {
                PhotonView.Get(this).RPC("OntakeOutBtn", RpcTarget.All);
                //OnActionBtn();
            }
            else
            {
                PhotonView.Get(this).RPC("OnPlaceBtn", RpcTarget.All);
                //OnPlaceBtn();
            }
        }
        if(Input.GetButton("Fire4"))
        {
            PhotonView.Get(this).RPC("OnActionBtn", RpcTarget.All);
            //OnZDown();

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

    public void GetGrabButtonDown()
    {
        if (!this.enabled)
            return;

        var equipment = es.hands.OccupyObj;

        if (equipment == null)
        {
            PhotonView.Get(this).RPC("OntakeOutBtn", RpcTarget.All);
        }
        else
        {
            PhotonView.Get(this).RPC("OnPlaceBtn", RpcTarget.All);
        }
    }

    public void GetKnifeButtonDown()
    {
        if (!this.enabled)
            return;

        if (!photonView.IsMine)
            return;

        PhotonView.Get(this).RPC("OnActionBtn", RpcTarget.All);
    }

    [PunRPC]
    public void OntakeOutBtn()
    {
        if (InteractableCursor.Cursor != null)
        {
            ITakeOut interactable = InteractableCursor.Cursor.GetComponent<ITakeOut>();
            if (interactable != null && interactable.TakeOut(es))
                EquipmentCursor.Cursor = null;
        }

        if (EquipmentCursor.Cursor != null)
        {
            ITakeOut interactable = EquipmentCursor.Cursor.GetComponent<ITakeOut>();
            if (interactable != null)
                interactable.TakeOut(es);
        }
    }

    [PunRPC]
    public void OnPlaceBtn()
    {
        if (InteractableCursor.Cursor != null)
        {
            IPlace interactable = InteractableCursor.Cursor.GetComponent<IPlace>();
            interactable.Place(es);
        }
        else
        {
            es.Unequip();
        }
    }

    [PunRPC]
    public void OnActionBtn()
    {
        if (InteractableCursor.Cursor != null)
        {
            InteractableAppliances interactable = InteractableCursor.Cursor.GetComponent<InteractableAppliances>();
            if (interactable != null)
            {
                CuttingBoard cb = interactable.slot.GetComponent<CuttingBoard>();
                if (cb != null)
                {
                    cb.Trigger(animator);
                }
            }
        }
    }
}
