using System;
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

    public GameObject knife;
    private bool isChoping;

    public GameObject plate;
    private bool isWashing;

    public float pickOrDropDelay;
    private bool isPickUp;
    private bool delay;

    private void Update()
    {
        Move();
        Action();
    }

    private void FixedUpdate()
    {
        if (!delay)
        {
            transform.position += moveVec * speed * Time.deltaTime;
        }
    }

    private void Move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(horizontal, 0f, vertical).normalized;
        transform.LookAt(transform.position + moveVec);

        if (moveVec != Vector3.zero)
        {
            if (isChoping)
            {
                isChoping = false;
                knife.SetActive(false);
                animator.SetBool("isChoping", false);
            }
            else if (isWashing)
            {
                isWashing = false;
                plate.SetActive(false);
                animator.SetBool("isWashing", false);
            }
        }
        animator.SetBool("isWalking", moveVec != Vector3.zero);
    }

    private void Action()
    {
        var canAction = !isChoping && !isWashing;
        //Debug.Log($"{canAction}, {Input.GetKeyDown(KeyCode.Space)}");
        if (canAction)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && !isPickUp)
            {
                Choping();
                //Washing();
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                PickUpOrDropDown();
            }
        }
    }

    private void Choping()
    {
        isChoping = true;
        knife.SetActive(true);
        animator.SetBool("isChoping", true);
    }

    private void Washing()
    {
        isWashing = true;
        plate.SetActive(true);
        animator.SetBool("isWashing", true);
    }

    private void PickUpOrDropDown()
    {
        moveVec = Vector3.zero;
        if (!isPickUp)
        {
            isPickUp = true;
            animator.SetBool("isPickUp", true);
        }
        else
        {
            isPickUp = false;
            animator.SetBool("isPickUp", false);
        }
        delay = true;
        Invoke(nameof(ActiveDelay), pickOrDropDelay);
    }

    private void ActiveDelay()
    {
        delay = false;
    }
}
