using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocationType
{
    SHELF,
    STOVE
}

public class InteractableLocation : Interactable
{
    public Slot slot;
    public LocationType type;

    public override void OnTakeOutBtnDown()
    {
        EquipmentSystem es = player.GetComponent<EquipmentSystem>();
        if (es == null || es.Equipment != null)
            return;

        GameObject ingrediant = slot.OnTakeOut();
        if (ingrediant != null)
            es.Equip(ingrediant);
    }
}
