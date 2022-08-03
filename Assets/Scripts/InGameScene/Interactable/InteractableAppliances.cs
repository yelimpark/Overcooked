using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAppliances : Interactable, ITakeOut, IPlace
{
    public Slot slot;

    public bool TakeOut(EquipmentSystem es)
    {
        if (!slot.AbleToTakeOut())
            return false;

        if (es.hands.AbleToPlace(slot.OccupyObj))
        {
            var takeOut = slot.OnTakeOut();
            es.Equip(takeOut);
            return true;
        }

        return false;
    }

    public bool Place(EquipmentSystem es)
    {
        if (slot.AbleToPlace(es.hands.OccupyObj))
        {
            var takeout = es.Unequip();
            es.UnequipEnd();
            slot.OnPlace(takeout);
            return true;
        }

        Slot cookware = es.hands.OccupyObj.GetComponent<Slot>();
        if (cookware != null && slot.AbleToPlace(cookware.OccupyObj))
        {
            var takeout = cookware.OnTakeOut();
            slot.OnPlace(takeout);
            return true;
        }

        return false;
    }
}
