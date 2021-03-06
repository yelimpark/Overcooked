using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInterection : MonoBehaviour
{
    public LayerMask target;
    public Transform dest;
    public float maxDistance = 10f;
    public bool activeDebug = true;

    private Vector3 direction;

    private void Start()
    {
        direction = dest.position - transform.position;
        direction.Normalize();
    }

    void Update()
    {
        if (activeDebug)
            Debug.DrawRay(transform.position, direction * maxDistance, Color.red);
    }

    public RaycastHit Shoot()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, direction, out hit, maxDistance, target);

        return hit;
    }
}
