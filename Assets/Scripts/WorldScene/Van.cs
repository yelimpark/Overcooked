using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Van : MonoBehaviour
{
    public float speed;

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

        horizontal = joystick.GetAxis("Horizontal") * speed;

        moveVec = new Vector3(horizontal, 0f, 0f).normalized;
        transform.LookAt(transform.position + moveVec);
    }

    private void FixedUpdate()
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
