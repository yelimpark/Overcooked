using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Van : MonoBehaviour
{
    public float speed;
    public bool canMove = true;

    private float horizontal; 
    private float vertical; 
    private Vector3 moveVec;

    private float minX = 0f;

    PhotonView photonView;

    public VirtualJoyStick joystick;


    private void Start()
    {
        photonView = PhotonView.Get(this);
    }

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        if (canMove)
        {
            //horizontal = Input.GetAxisRaw("Horizontal");
            float h = joystick.GetAxis("Horizontal") * speed;

            moveVec = new Vector3(h, 0f, 0f).normalized;
            transform.LookAt(transform.position + moveVec);
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            transform.position += moveVec * speed * Time.deltaTime;

            if (transform.position.x < minX)
            {
                var pos = transform.position;
                pos.x = minX;
                transform.position = pos;
            }
        }
    }
}
