using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    protected List<GameObject> collisions = new List<GameObject>();

    protected GameObject cursor;
    public virtual GameObject Cursor
    {
        get { return cursor; }
        set { cursor = value; }
    }

    protected string InteracableTag;

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
        RaycastHit hit;
        Vector3 direction = transform.forward + transform.up * (-1);
        Physics.Raycast(transform.position, direction.normalized, out hit, Utils.RAY_MAX_LENGTH);

        Transform hitted = hit.transform;

        if (hitted != null && collisions.Count > 1 && collisions.Contains(hitted.gameObject))
        {
            Cursor = hitted.gameObject;
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
