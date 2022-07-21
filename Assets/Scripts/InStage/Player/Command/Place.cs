using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : Command
{
    EquipmentSystem es;
    GameObject cursor;

    public Place(EquipmentSystem es, GameObject cursor)
    {
        this.es = es;
        this.cursor = cursor;
    }

    public override void Execute()
    {
        if (cursor != null)
        {
            InteractableAppliances interactable = cursor.GetComponent<InteractableAppliances>();
            if (interactable != null && interactable.slot.AbleToPlace(es.Equipment))
            {
                GameObject discarded = es.Unequip();
                interactable.slot.OnPlace(discarded);
            }
        }
        es.Unequip();
    }
}
