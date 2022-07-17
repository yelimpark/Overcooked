using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAppliances : Interactable
{
    public Slot slot;

    public override void OnTakeOutBtnDown()
    {
        EquipmentSystem es = player.GetComponent<EquipmentSystem>();
        if (es == null || es.Equipment != null)
            return;

        GameObject ingrediant = null;
        switch(slot)
        {
            case Cookware cookware:
                ingrediant = cookware.OnTakeOut();
                break;
            case Appliances appliances:
                ingrediant = appliances.OnTakeOut();
                break;
            default:
                ingrediant = slot.OnTakeOut();
                break;
        }
        if (ingrediant != null)
            es.Equip(ingrediant);
    }
}
