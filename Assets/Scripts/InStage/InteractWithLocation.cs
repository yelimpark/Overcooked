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
            Highlight highlight;

            if (cursor != null)
            {
                highlight = cursor.GetComponent<Highlight>();
                if (highlight != null)
                    highlight.TurnOff();
            }

            cursor = value;

            if (cursor != null)
            {
                highlight = cursor.GetComponent<Highlight>();
                if (highlight != null)
                    highlight.TurnOn();
            }
        }
    }

    void Start()
    {
        rayInterection = GetComponent<RayInterection>();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Transform hit = rayInterection.Shoot().transform;
            if (hit != null && collisions.Count > 1 && collisions.Contains(hit.gameObject))
            {
                Cursor = hit.gameObject;
            }
        }

        if (Input.GetButtonDown("Fire1") && cursor != null)
        {
            Transform shelf = cursor.transform.GetChild(0);
            InteractableLocation il = shelf.GetComponent<InteractableLocation>();
            GameObject ingrediant = il.OnTakeOut();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Interactable") && !other.isTrigger)
            return;

        Cursor = other.gameObject;
        collisions.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Interactable") && !other.isTrigger)
            return;

        GameObject go = other.gameObject;

        collisions.Remove(go);
        if (go.Equals(cursor))
            Cursor = null;
    }
}
