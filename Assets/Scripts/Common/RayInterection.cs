using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayInterection : MonoBehaviour
{
    public LayerMask target;
    public float maxDistance = 10f;
    public bool activeDebug = true;
    private Vector3 direction;
    public float angle;
    public bool absolute = false;

    void Update()
    {
        if (!absolute)
        {
            direction = Quaternion.AngleAxis(angle, Vector3.up) * transform.forward;
        }

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
