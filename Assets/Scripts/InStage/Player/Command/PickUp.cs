using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Command
{
    EquipmentSystem es;
    GameObject cursor;

    public PickUp(EquipmentSystem es, GameObject cursor)
    {
        this.es = es;
        this.cursor = cursor;
    }

    public override void Execute()
    {
        var dest = es.EquipableTo();
        Interactable interactable = cursor.GetComponent<Interactable>();
        if (interactable != null)
        {
            var takeOut = interactable.TakeOut(dest);
            es.Equip(takeOut);
        }
    }
}
