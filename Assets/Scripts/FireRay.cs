using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRay : MonoBehaviour
{
    public float distance = 2f;
    private RaycastHit rayHit;
    private Ray ray;

    public int damage = 15;

    public ParticleSystem extingParticle;
    public FireHp fireHp;

    public void Awake()
    {
        extingParticle = GetComponent<ParticleSystem>();

        ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;
    }

    public void Update()
    {
        OnDrawGizmos();
        if (Physics.Raycast(ray.origin, ray.direction, out rayHit, distance))
        {
            //Debug.Log(rayHit.collider.gameObject.name);
            fireHp = rayHit.collider.GetComponent<FireHp>();
            if(fireHp != null)
            {
                fireHp.TakeDamage(damage);
            }
        } 
    }

    public void Spread()
    {
        extingParticle.Stop();
        extingParticle.Play();
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
    }
}

