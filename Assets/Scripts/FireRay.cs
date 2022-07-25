using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRay : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;

    public float distance = 2f;
    private RaycastHit rayHit;
    private Ray ray;

    public int damage = 15;

    public ParticleSystem extingParticle;
    public FireHp fireHp;

    public void Awake()
    {
        extingParticle = GetComponentInChildren<ParticleSystem>();        
        ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.forward;
    }

    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnDrawGizmos();
            Shoot();
        }   
        
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);
    }

    public void Shoot()
    {
        extingParticle.Play();
        if (Physics.Raycast(ray.origin, ray.direction, out rayHit, distance, layerMask))
        {
            fireHp = rayHit.collider.GetComponent<FireHp>();
            if(fireHp != null)
            {
                fireHp.TakeDamage(damage);
            } 
        }
    }
}

