using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Van : MonoBehaviour
{
    public float speed;
    public bool canMove = true;

    private float horizontal;
    private Vector3 moveVec;

    private float minX = 0f;

    private void Update()
    {
        if (canMove)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            moveVec = new Vector3(horizontal, 0f, 0f).normalized;
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
