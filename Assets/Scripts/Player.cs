using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Animator animator;

    private float horizontal;
    private float vertical;
    private Vector3 moveVec;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        transform.position += moveVec * speed * Time.deltaTime;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(horizontal, 0f, vertical).normalized;
        transform.LookAt(transform.position + moveVec);

        animator.SetBool("isWalking", moveVec != Vector3.zero);
    }
}
