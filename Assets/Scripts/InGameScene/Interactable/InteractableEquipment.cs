using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableEquipment : Interactable, ITakeOut
{
    public bool TakeOut(EquipmentSystem es)
    {
        if (es.hands.AbleToPlace(gameObject))
        {
            es.Equip(gameObject);
            return true;
        }

        return false;
    }
}
