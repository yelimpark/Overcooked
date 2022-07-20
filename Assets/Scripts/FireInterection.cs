using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInterection : MonoBehaviour
{
    public float maxDistance = 5f;
    public Transform fire;
    Ray ray;

    public Vector3 direction;

    public void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position;      
        
    }

    public void Update()
    {
        Debug.DrawRay(transform.position, direction * maxDistance, Color.blue);
    }



    public RaycastHit Shoot()
    {
        direction = fire.position - transform.position;
        direction.Normalize();

        RaycastHit FireHit;

        Physics.Raycast(ray.origin, ray.direction, out FireHit, maxDistance);
        return FireHit;
    }


}
