using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLocation : Interactable
{
    public override void OnTakeOutBtnDown()
    {
        EquipmentSystem es = player.GetComponent<EquipmentSystem>();
        if (es == null || es.Equipment != null)
            return;

        GameObject ingrediant = shelf.OnTakeOut();
        if (ingrediant != null)
            es.Equip(ingrediant);
        
    }
}
