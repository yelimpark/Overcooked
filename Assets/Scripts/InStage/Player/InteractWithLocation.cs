using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithLocation : MonoBehaviour
{
    private RayInterection rayInterection;
    private List<GameObject> collisions = new List<GameObject>();
    
    private GameObject cursor;
    public GameObject Cursor
    {
        get { return cursor; }
        set 
        {
            InteractableLocation il;

            if (cursor != null)
            {
                il = cursor.GetComponent<InteractableLocation>();
                if (il != null)
                    il.Active = false;
            }

            cursor = value;

            if (cursor != null)
            {
                il = cursor.GetComponent<InteractableLocation>();
                if (il != null)
                    il.Active = true;
            }
        }
    }

    void Start()
    {
        rayInterection = GetComponent<RayInterection>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            Transform hit = rayInterection.Shoot().transform;
            if (hit != null && collisions.Count > 1 && collisions.Contains(hit.gameObject))
            {
                Cursor = hit.gameObject;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            EquipmentSystem es = GetComponent<EquipmentSystem>();

            if (es != null && es.Equipment != null)
            {
                GameObject discarded = es.Unequip();

                if (cursor != null) {
                    InteractableLocation il = cursor.GetComponent<InteractableLocation>();
                    if (il != null)
                        il.shelf.OnPlace(discarded);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collider other = collision.collider;

        if (!other.CompareTag("Interactable") && !other.isTrigger)
            return;

        Cursor = other.gameObject;
        collisions.Add(other.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        Collider other = collision.collider;

        if (!other.CompareTag("Interactable") && !other.isTrigger)
            return;

        GameObject go = other.gameObject;

        collisions.Remove(go);
        if (go.Equals(cursor))
            Cursor = null;
    }
}
