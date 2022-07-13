using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLocation : MonoBehaviour
{
    private bool active = false;

    public Shelf shelf;
    public GameObject player;

    public bool Active
    {
        get { return active; }
        set 
        { 
            active = value;
            if (active)
            {
                OnCursorOn();
            }
            else
            {
                OnCursorOut();
            }
        }
    }

    public void OnCursorOn()
    {
        Highlight highlight = GetComponent<Highlight>();
        if (highlight != null)
            highlight.TurnOn();
    }

    public void OnCursorOut()
    {
        Highlight highlight = GetComponent<Highlight>();
        if (highlight != null)
            highlight.TurnOff();
    }

    private void Update()
    {
        if (active && Input.GetButtonDown("Fire1"))
        {
            EquipmentSystem es = player.GetComponent<EquipmentSystem>();
            if (es == null || es.Equipment != null)
                return;

            GameObject ingrediant = shelf.OnTakeOut();
            if (ingrediant != null)
                es.Equip(ingrediant);
        }
    }
}
