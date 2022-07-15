using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    public float speed;

    private Vector3 offset;
    private float limitX;

    private void Awake()
    {
        offset = transform.position - target.transform.position;
        limitX = transform.position.x;
    }

    private void Update()
    {
        var newPos = target.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);

        if (transform.position.x < limitX)
        {
            var pos = transform.position;
            pos.x = limitX;
            transform.position = pos;
        }
    }
}
