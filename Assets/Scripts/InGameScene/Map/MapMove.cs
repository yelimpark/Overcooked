using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{    
    public Transform targetPos;
    public Transform originPos;
    public Transform desPos;

    public float speed = 5f;

    private void Start()
    {
        transform.position = originPos.position;
        desPos = targetPos;
    }
    private void FixedUpdate()
    {
        StartCoroutine(CoMapMovement());
    }
    public IEnumerator CoMapMovement()
    {
        yield return new WaitForSeconds(5f);
        transform.position = Vector3.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if (desPos == targetPos)
            {
                desPos = originPos;
            }
            else
            {
                desPos = targetPos;
            }
        }
    }
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, desPos.position) <= 0.05f)
        {
            if (desPos == targetPos)
            {
                desPos = originPos;
            }
            else
            {
                desPos = targetPos;
            }
        }
    }
}
