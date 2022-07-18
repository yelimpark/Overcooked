using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAppliances : Interactable
{
    public Slot slot;

    public override void OnTakeOutBtnDown(EquipmentSystem es)
    {
        if (es.Equipment != null)
            return;

        if (!slot.AbleToTakeOut(es.gameObject))
            return;

        GameObject ingrediant = slot.OnTakeOut(es.gameObject);

        if (ingrediant != null)
            es.Equip(ingrediant);
    }
}
