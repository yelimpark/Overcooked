using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithLocation : MonoBehaviour
{
    private GameObject cursor;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("fire1") && cursor != null)
        {
            Transform shelf = cursor.transform.GetChild(0);
            InteractableLocation il = shelf.GetComponent<InteractableLocation>();
            GameObject ingrediant = il.OnTakeOut();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Interactable"))
            return;

        Highlight highlight;

        if (cursor != null)
        {
            highlight = cursor.GetComponent<Highlight>();
            if (highlight != null)
                highlight.TurnOff();
        }

        cursor = other.gameObject;

        highlight = cursor.GetComponent<Highlight>();
        if (highlight != null)
            highlight.TurnOn();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Interactable"))
            return;

        Highlight highlight = other.GetComponent<Highlight>();
        if (highlight != null)
            highlight.TurnOff();
    }
}
