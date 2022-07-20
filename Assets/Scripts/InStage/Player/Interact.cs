using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public List<string> tags = new List<string>();

    protected List<GameObject> collisions = new List<GameObject>();

    protected GameObject cursor;
    public virtual GameObject Cursor
    {
        get { return cursor; }
        set
        {
            Interactable il;

            if (cursor != null)
            {
                il = cursor.GetComponent<Interactable>();
                if (il != null)
                    il.Active = false;
            }

            cursor = value;

            if (cursor != null)
            {
                il = cursor.GetComponent<Interactable>();
                if (il != null)
                    il.Active = true;
            }
        }
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
        RaycastHit hit;
        Vector3 direction = transform.forward + transform.up * (-1);
        Physics.Raycast(transform.position, direction.normalized, out hit, Utils.RAY_MAX_LENGTH);

        Transform hitted = hit.transform;

        if (hitted != null && collisions.Count > 1 && collisions.Contains(hitted.gameObject))
        {
            Cursor = hitted.gameObject;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            Cursor = other.gameObject;
            collisions.Add(other.gameObject);
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (tags.Contains(other.tag))
        {
            GameObject go = other.gameObject;

            collisions.Remove(go);
            if (go.Equals(cursor))
                Cursor = null;
        }
    }
}
