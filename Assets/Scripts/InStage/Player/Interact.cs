using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    protected RayInterection rayInterection;
    protected List<GameObject> collisions = new List<GameObject>();
    
    protected GameObject cursor;
    public virtual GameObject Cursor
    {
        get { return cursor; }
        set { cursor = value; }
    }

    protected string InteracableTag;

    public virtual void Start()
    {
        rayInterection = GetComponent<RayInterection>();
    }

    public virtual void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            OnMove();
        }
    }

    public void OnMove()
    {
        Transform hit = rayInterection.Shoot().transform;
        if (hit != null && collisions.Count > 1 && collisions.Contains(hit.gameObject))
        {
            Cursor = hit.gameObject;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;

        if (!other.CompareTag(InteracableTag) && !other.isTrigger)
            return;

        Cursor = other.gameObject;
        collisions.Add(other.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        Collider other = collision.collider;

        if (!other.CompareTag(InteracableTag) && !other.isTrigger)
            return;

        GameObject go = other.gameObject;

        collisions.Remove(go);
        if (go.Equals(cursor))
            Cursor = null;
    }
}
